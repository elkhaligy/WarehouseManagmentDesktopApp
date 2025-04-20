using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace WarehouseManagement.Modal_Forms
{
    public partial class WarehousesItems : Form
    {
        private readonly Warehouse _warehouse;
        private BindingSource bindingSource;
        private WarehouseContext _context;

        public WarehousesItems(Warehouse warehouse)
        {
            InitializeComponent();
            _warehouse = warehouse;
            _context = new WarehouseContext();
            this.Text = $"Items in {warehouse.Name}";
            LoadWarehouseItems();
            SetupGrid();
            this.BackColor = ColorTranslator.FromHtml("#3c4649");
            int titleBarColor = ColorTranslator.ToWin32(ColorTranslator.FromHtml("#2d2f31"));
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref titleBarColor, sizeof(int));
        }

        private void LoadWarehouseItems()
        {
            // Load the items for this warehouse including the Item details
            var warehouse = _context.Warehouses.Include(w => w.WarehouseItems).ThenInclude(wi => wi.Item).FirstOrDefault(w => w.Id == _warehouse.Id);

            var items = warehouse.WarehouseItems.Select(wi => new {
                ItemId = wi.ItemId,
                ItemName = wi.Item.Name,
                Quantity = wi.Quantity,
                ProductionDate = wi.ProductionDate,
                ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays),
                
            }).ToList();
            itemsDataGrid.DataSource = items;
        }

        private void SetupGrid()
        {
            // Hide navigation properties and IDs
            //itemsDataGrid.Columns["Warehouse"].Visible = false;
            //itemsDataGrid.Columns["WarehouseId"].Visible = false;
            itemsDataGrid.Columns["ItemId"].Visible = false;

            // Configure auto-size
            itemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        const int DWMWA_CAPTION_COLOR = 35;

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
    }
}
