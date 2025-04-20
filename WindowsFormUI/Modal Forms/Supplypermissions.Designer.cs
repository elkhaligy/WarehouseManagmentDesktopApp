namespace WarehouseManagement.Modal_Forms
{
    partial class Supplypermissions
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
            itemsDataGrid = new ReaLTaiizor.Controls.PoisonDataGridView();
            ((System.ComponentModel.ISupportInitialize)itemsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // itemsDataGrid
            // 
            itemsDataGrid.AllowUserToResizeRows = false;
            itemsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            itemsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            itemsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            itemsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            itemsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            itemsDataGrid.EnableHeadersVisualStyles = false;
            itemsDataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            itemsDataGrid.GridColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemsDataGrid.Location = new System.Drawing.Point(39, 12);
            itemsDataGrid.Name = "itemsDataGrid";
            itemsDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            itemsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            itemsDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            itemsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            itemsDataGrid.Size = new System.Drawing.Size(710, 403);
            itemsDataGrid.TabIndex = 0;
            // 
            // form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(itemsDataGrid);
            Name = "form";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "form";
            ((System.ComponentModel.ISupportInitialize)itemsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView itemsDataGrid;
    }
}