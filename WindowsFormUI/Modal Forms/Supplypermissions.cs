using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Windows.Forms;
using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace WarehouseManagement.Modal_Forms
{
    public partial class Supplypermissions : Form
    {
        private readonly Supplier _supplier;
        private WarehouseContext _context;

        public Supplypermissions(Supplier supplier)
        {
            InitializeComponent();
            _supplier = supplier;
            _context = new WarehouseContext();
            this.Text = $"Supply Permissions of {_supplier.Name}";
            LoadSupplypermissions();
            SetupGrid();
        }

        private void LoadSupplypermissions()
        {
            // Load the items for this warehouse including the Item details
            var supplier = _context.Suppliers.Include(s => s.SupplyPermissions).ThenInclude(sp => sp.Warehouse).FirstOrDefault(s => s.Id == _supplier.Id);

            var transformedObject = supplier.SupplyPermissions.Select(sp => new {
                PermissionNumber = sp.PermissionNumber,
                PermissionDate = sp.PermissionDate,
                Warehouse = sp.Warehouse.Name,
            }).ToList();
            itemsDataGrid.DataSource = transformedObject;
        }

        private void SetupGrid()
        {
            // Hide navigation properties and IDs
            //itemsDataGrid.Columns["Warehouse"].Visible = false;
            //itemsDataGrid.Columns["WarehouseId"].Visible = false;
            //itemsDataGrid.Columns["ItemId"].Visible = false;
            
            // Configure auto-size
            itemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
