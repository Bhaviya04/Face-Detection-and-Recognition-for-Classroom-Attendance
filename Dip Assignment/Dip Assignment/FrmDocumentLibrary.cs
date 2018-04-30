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
    public partial class FrmDocumentLibrary : Form
    {
        private String _folderPath = Application.StartupPath + "/books/";
        public FrmDocumentLibrary()
        {
            InitializeComponent();
        }

        private void FrmDocumentLibrary_Load(object sender, EventArgs e)
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
                        dataGridBooks.Rows.Add(new object[] { image, Path.GetFileName(fileNames[i]) });
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
        
        private void dataGridBooks_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fileName = _folderPath + (String)dataGridBooks.Rows[e.RowIndex].Cells["File Name"].Value;
            var pdfViewer = new FrmPDFViewer(fileName);
            pdfViewer.Show();
        }
    }
}
