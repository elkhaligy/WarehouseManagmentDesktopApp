namespace WarehouseManagement.Modal_Forms
{
    partial class WarehousesItems
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
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(0, 177, 89);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            itemsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            itemsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            itemsDataGrid.EnableHeadersVisualStyles = false;
            itemsDataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            itemsDataGrid.GridColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemsDataGrid.Location = new System.Drawing.Point(106, 96);
            itemsDataGrid.Name = "itemsDataGrid";
            itemsDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(0, 177, 89);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            itemsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            itemsDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            itemsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            itemsDataGrid.Size = new System.Drawing.Size(600, 300);
            itemsDataGrid.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            itemsDataGrid.TabIndex = 0;
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = System.Drawing.Color.Transparent;
            foxBigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = System.Drawing.Color.White;
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new System.Drawing.Point(303, 35);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new System.Drawing.Size(181, 41);
            foxBigLabel1.TabIndex = 14;
            foxBigLabel1.Text = "Current Stock";
            // 
            // WarehousesItems
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(foxBigLabel1);
            Controls.Add(itemsDataGrid);
            Name = "WarehousesItems";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "form";
            ((System.ComponentModel.ISupportInitialize)itemsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView itemsDataGrid;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
    }
}