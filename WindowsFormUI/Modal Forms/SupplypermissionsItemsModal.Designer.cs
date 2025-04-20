namespace WarehouseManagement.Modal_Forms
{
    partial class SupplypermissionsItemsModal
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
            girdView = new ReaLTaiizor.Controls.PoisonDataGridView();
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            ((System.ComponentModel.ISupportInitialize)girdView).BeginInit();
            SuspendLayout();
            // 
            // girdView
            // 
            girdView.AllowUserToResizeRows = false;
            girdView.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            girdView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            girdView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            girdView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(0, 177, 89);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            girdView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            girdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            girdView.DefaultCellStyle = dataGridViewCellStyle2;
            girdView.EnableHeadersVisualStyles = false;
            girdView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            girdView.GridColor = System.Drawing.Color.FromArgb(255, 255, 255);
            girdView.Location = new System.Drawing.Point(104, 92);
            girdView.Name = "girdView";
            girdView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(0, 177, 89);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(0, 208, 104);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            girdView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            girdView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            girdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            girdView.Size = new System.Drawing.Size(600, 300);
            girdView.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            girdView.TabIndex = 12;
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = System.Drawing.Color.Transparent;
            foxBigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = System.Drawing.Color.White;
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new System.Drawing.Point(261, 21);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new System.Drawing.Size(276, 41);
            foxBigLabel1.TabIndex = 13;
            foxBigLabel1.Text = "Items in Supply Order";
            // 
            // SupplypermissionsItemsModal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(foxBigLabel1);
            Controls.Add(girdView);
            Name = "SupplypermissionsItemsModal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)girdView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView girdView;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
    }
}