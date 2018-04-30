namespace Dip_Assignment
{
    partial class FrmDocumentLibrary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(610, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dataGridBooks
            // 
            this.dataGridBooks.AllowUserToAddRows = false;
            this.dataGridBooks.AllowUserToDeleteRows = false;
            this.dataGridBooks.AllowUserToResizeColumns = false;
            this.dataGridBooks.AllowUserToResizeRows = false;
            this.dataGridBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridBooks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBooks.ColumnHeadersVisible = false;
            this.dataGridBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBooks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBooks.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridBooks.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridBooks.Location = new System.Drawing.Point(0, 0);
            this.dataGridBooks.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridBooks.MultiSelect = false;
            this.dataGridBooks.Name = "dataGridBooks";
            this.dataGridBooks.ReadOnly = true;
            this.dataGridBooks.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            this.dataGridBooks.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridBooks.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.dataGridBooks.RowTemplate.DividerHeight = 5;
            this.dataGridBooks.RowTemplate.Height = 60;
            this.dataGridBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBooks.Size = new System.Drawing.Size(822, 564);
            this.dataGridBooks.TabIndex = 1;
            this.dataGridBooks.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBooks_CellContentDoubleClick);
            // 
            // FrmDocumentLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 564);
            this.Controls.Add(this.dataGridBooks);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumentLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Library";
            this.Load += new System.EventHandler(this.FrmDocumentLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridBooks;
    }
}