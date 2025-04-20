using Microsoft.EntityFrameworkCore;
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
    public partial class SupplypermissionsItemsModal : Form
    {
        private readonly SupplyPermission _supplyPermission;
        private WarehouseContext _context;
        public SupplypermissionsItemsModal(SupplyPermission supplyPermission)
        {
            InitializeComponent();
            _supplyPermission = supplyPermission;
            _context = new WarehouseContext();
            this.Text = $"Items of Supply Permission Number {supplyPermission.PermissionNumber}";
            LoadSupplypermissions();
            this.BackColor = ColorTranslator.FromHtml("#3c4649");
            int titleBarColor = ColorTranslator.ToWin32(ColorTranslator.FromHtml("#2d2f31"));
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref titleBarColor, sizeof(int));

        }

        private void LoadSupplypermissions()
        {
            // Load the items for this warehouse including the Item details
            var supplyPermission = _context.SupplyPermissions.Include(sp => sp.Items).ThenInclude(spi => spi.Item).FirstOrDefault(sp => sp.Id == _supplyPermission.Id);

            var transformedObject = supplyPermission.Items.Select(spi => new {
                //DestinationWarehouse = supplyPermission.Warehouse.Name,
                spi.Item.Name,
                spi.Quantity,
                spi.ProductionDate,
                spi.ExpiryDurationInDays,

            }).ToList();
            girdView.DataSource = transformedObject;
            girdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }




        const int DWMWA_CAPTION_COLOR = 35;

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);


    }
}
