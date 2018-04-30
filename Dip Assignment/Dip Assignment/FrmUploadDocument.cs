using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dip_Assignment
{
    public partial class FrmUploadDocument : Form
    {
        private String _folderPath = Application.StartupPath + "/books/";
        public FrmUploadDocument()
        {
            InitializeComponent();
        }

        private void FrmUploadDocument_Load(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void LoadDocuments()
        {
            try
            {
                dataGridBooks.Columns.Clear();
                dataGridBooks.Rows.Clear();
                String[] fileNames = Directory.GetFiles(_folderPath);
                if (fileNames.Length > 0)
                {
                    var image = Image.FromFile(Application.StartupPath + "/pdf-icon_edit.png");
                    var imgIcon = new DataGridViewImageColumn();
                    imgIcon.ImageLayout = DataGridViewImageCellLayout.Normal;
                    imgIcon.Image = image;
                    imgIcon.HeaderText = "Image";
                    imgIcon.Name = "img";
                    dataGridBooks.Columns.Add(imgIcon);
                    dataGridBooks.Columns.Add("File Name", "File Name");
                    
                    for (var i = 0; i < fileNames.Length; i++)
                    {
                        dataGridBooks.Rows.Add(new object[]{image, Path.GetFileName(fileNames[i])});
                    }
                }
                else
                    MessageBox.Show("There are no books in your library", "E-Book Library", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            catch (DirectoryNotFoundException ex)
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectPdfFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String filePath = Path.GetFullPath(selectPdfFileDialog.FileName);
                    File.Copy(filePath, _folderPath + Path.GetFileName(filePath),true);
                    MessageBox.Show("File Uploaded Successfully");
                    LoadDocuments();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowCount = dataGridBooks.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        var fileName = (String) dataGridBooks.SelectedRows[i].Cells["File Name"].Value;
                        File.Delete(_folderPath+fileName);
                    }
                    LoadDocuments();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void dataGridBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fileName = _folderPath + (String) dataGridBooks.Rows[e.RowIndex].Cells["File Name"].Value;
            var pdfViewer = new FrmPDFViewer(fileName);
            pdfViewer.Show();
        }
    }
}
