using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using WarehouseManagement.Modal_Forms;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagement
{
    public partial class MainForm : Form
    {
        private static WarehouseContext _context = new WarehouseContext();
        private List<SupplyPermissionItem> supplyPermissionItems = new List<SupplyPermissionItem>();
        private List<ReleasePermissionItem> releasePermissionItems = new List<ReleasePermissionItem>();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Commercial Company Management";
            this.BackColor = ColorTranslator.FromHtml("#F6F0F0");
            int titleBarColor = ColorTranslator.ToWin32(ColorTranslator.FromHtml("#2d2f31"));
            this.Text = "Warehouse Management";

            SetupWarehouseTab();
            SetupSuppliersTab();
            SetupCustomerTab();
            SetupReportsTab();
            SetupReleasePermissionsTab();
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref titleBarColor, sizeof(int));

        }
        #region Warehouse Tab
        private void SetupWarehouseTab()
        {
            _context.Warehouses.Load();
            gridViewWarehouse.DataSource = _context.Warehouses.Local.ToBindingList();
            gridViewWarehouse.Columns["WarehouseItems"].Visible = false;
            gridViewWarehouse.Columns["SupplyPermissions"].Visible = false;
            gridViewWarehouse.Columns["ReleasePermissions"].Visible = false;
            gridViewWarehouse.Columns["SourceTransfers"].Visible = false;
            gridViewWarehouse.Columns["DestinationTransfers"].Visible = false;
            gridViewWarehouse.Columns["Id"].Visible = false;
            gridViewWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewWarehouse.ContextMenuStrip = contextMenuStrip1;

        }
        private void tabPage8_Enter(object sender, EventArgs e)
        {
            SetupWarehouseTab();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {

            _context.SaveChanges();
            MessageBox.Show("DB Updated Successfully!");
        }

        private void itemsDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridViewWarehouse.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0) // Ensure click is on a row
                {
                    gridViewWarehouse.ClearSelection(); // Deselect all rows
                    gridViewWarehouse.Rows[hit.RowIndex].Selected = true; // Select the right-clicked row
                    gridViewWarehouse.CurrentCell = gridViewWarehouse.Rows[hit.RowIndex].Cells[0]; // Set focus

                    contextMenuStrip1.Show(gridViewWarehouse, e.Location); // Show context menu
                }
            }
        }
        private void itemsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var selectedWarehouse = (Warehouse)gridViewWarehouse.CurrentRow.DataBoundItem;
            WarehousesItems modalForm = new WarehousesItems(selectedWarehouse);
            modalForm.ShowDialog();
        }

        #endregion




        private void SetupSuppliersTab()
        {
            _context.Suppliers.Load();
            suppliersGridView.DataSource = _context.Suppliers.Local.ToBindingList();
            suppliersGridView.Columns["SupplyPermissions"].Visible = false;
            suppliersGridView.Columns["WarehouseItems"].Visible = false;
            suppliersGridView.Columns["Id"].Visible = false;
            suppliersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            suppliersGridView.ContextMenuStrip = contextMenuStrip2;

        }

        private void SetupCustomerTab()
        {
            _context.Customers.Load();
            customerDataGridView1.DataSource = _context.Customers.Local.ToBindingList();
            customerDataGridView1.Columns["Id"].Visible = false;
            customerDataGridView1.Columns["ReleasePermissions"].Visible = false;
            customerDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //customerDataGridView1.ContextMenuStrip = contextMenuStrip2;

        }


        private void customerSaveButton_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
            MessageBox.Show("Customer Added/Edited Succesfully!");
        }



        private void createReleasePermissionButton_Click(object sender, EventArgs e)
        {

        }

        #region Supply Permission Tab
        private void SetupSupplypermissionsTab()
        {
            _context.SupplyPermissions.Load();
            supplypermissionsDataGridView1.DataSource = _context.SupplyPermissions.Local.ToBindingList();
            //supplypermissionsDataGridView1.Columns["Id"].Visible = false;
            supplypermissionsDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var warehouses = _context.Warehouses.Select(w => new { Id = w.Id, Name = w.Name }).ToList();

            warehouseCombobox.DataSource = null;
            warehouseCombobox.DataSource = warehouses;
            warehouseCombobox.DisplayMember = "Name";
            warehouseCombobox.ValueMember = "Id";

            var suppliers = _context.Suppliers.Select(s => new { s.Id, s.Name }).ToList();
            supplierComboBox1.DataSource = null;
            supplierComboBox1.DataSource = suppliers.ToList();
            supplierComboBox1.DisplayMember = "Name";
            supplierComboBox1.ValueMember = "Id";

            var items = _context.Items.Select(i => new { i.Id, i.Name, i.Code }).ToList();
            itemsComboBox.DataSource = null;
            itemsComboBox.DataSource = items;
            itemsComboBox.DisplayMember = "Name";
            itemsComboBox.ValueMember = "Id";

            supplypermissionsDataGridView1.Columns["WarehouseId"].Visible = false;
            supplypermissionsDataGridView1.Columns["SupplierId"].Visible = false;
            supplypermissionsDataGridView1.Columns["Id"].Visible = false;
            supplypermissionsDataGridView1.Columns["Items"].Visible = false;

            supplypermissionsDataGridView1.ContextMenuStrip = supplyPermissionscontextMenuStrip3;

        }
        private void foreverTabPage1_Click(object sender, EventArgs e)
        {
            SetupSupplypermissionsTab();
        }
        private void addItemButton_Click(object sender, EventArgs e)
        {
            // Construct supply permission object
            var supplyPermissionItem = new SupplyPermissionItem
            {
                ItemId = (int)itemsComboBox.SelectedValue,
                Quantity = Int32.Parse(itemQuantityTextBox1.Text),
                ProductionDate = itemProductionDateTime1.Value,
                ExpiryDurationInDays = Int32.Parse(itemExpirtyTextBox2.Text)
            };
            supplyPermissionItems.Add(supplyPermissionItem);
            dynamic selected = itemsComboBox.SelectedItem;
            string selectedText = selected.Name;
            addedItemsTextbox.Text += $" {selectedText} : {itemQuantityTextBox1.Text} {Environment.NewLine}";


            MessageBox.Show("Item Added Successfully!");
        }
        private void finishSupplyPerimssionButton2_Click(object sender, EventArgs e)
        {
            var supplyPermission = new SupplyPermission
            {
                PermissionNumber = supplyPermissionNumberTextbox.Text,
                PermissionDate = supplyPermissionDateDateTime2.Value,
                WarehouseId = (int)warehouseCombobox.SelectedValue,
                SupplierId = (int)supplierComboBox1.SelectedValue,
                Items = supplyPermissionItems
            };

            foreach (var item in supplyPermissionItems)
            {
                var existingWarehouseItem = _context.WarehouseItems
     .FirstOrDefault(wi => wi.WarehouseId == (int)warehouseCombobox.SelectedValue &&
                         wi.ItemId == item.ItemId
                   );

                if (existingWarehouseItem != null)
                {
                    existingWarehouseItem.Quantity += item.Quantity;
                }
                else
                {
                    _context.WarehouseItems.Add(new WarehouseItem
                    {
                        WarehouseId = (int)warehouseCombobox.SelectedValue,
                        ItemId = item.ItemId,
                        SupplierId = (int)supplierComboBox1.SelectedValue,
                        Quantity = item.Quantity,
                        ProductionDate = item.ProductionDate,
                        ExpiryDateInDays = item.ExpiryDurationInDays
                    });
                }
            }
            _context.SupplyPermissions.Add(supplyPermission);
            _context.SaveChanges();
            supplyPermissionItems.Clear();
            MessageBox.Show("Supply Permission Added Successfully!");
        }
        private void supplyItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedPermission = (SupplyPermission)supplypermissionsDataGridView1.CurrentRow.DataBoundItem;
            SupplypermissionsItemsModal modalForm = new SupplypermissionsItemsModal(selectedPermission);
            modalForm.ShowDialog();
        }

        private void supplyPermissionsDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = supplypermissionsDataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0) // Ensure click is on a row
                {
                    supplypermissionsDataGridView1.ClearSelection(); // Deselect all rows
                    supplypermissionsDataGridView1.Rows[hit.RowIndex].Selected = true; // Select the right-clicked row
                    supplypermissionsDataGridView1.CurrentCell = supplypermissionsDataGridView1.Rows[hit.RowIndex].Cells[0]; // Set focus

                    //supplyPermissionscontextMenuStrip3.Show(gridViewWarehouse, e.Location); // Show context menu
                }
            }
        }

        #endregion


        #region Release Permission Tab
        private void SetupReleasePermissionsTab()
        {
            _context.ReleasePermissions.Load();
            releasePermissionsDataGridView.DataSource = _context.ReleasePermissions.Local.ToBindingList();
            releasePermissionsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Load warehouses
            var warehouses = _context.Warehouses.Select(w => new { Id = w.Id, Name = w.Name }).ToList();
            warehouseComboBox2.DataSource = warehouses;
            warehouseComboBox2.DisplayMember = "Name";
            warehouseComboBox2.ValueMember = "Id";

            // Load customers
            var customers = _context.Customers.Select(c => new { c.Id, c.Name }).ToList();
            customerComboBox2.DataSource = customers;
            customerComboBox2.DisplayMember = "Name";
            customerComboBox2.ValueMember = "Id";

            // Load items
            var items = _context.Items.Select(i => new { i.Id, i.Name, i.Code }).ToList();
            additemComboBox1.DataSource = items;
            additemComboBox1.DisplayMember = "Name";
            additemComboBox1.ValueMember = "Id";

            // Hide navigation properties and IDs in the grid
            releasePermissionsDataGridView.Columns["WarehouseId"].Visible = false;
            releasePermissionsDataGridView.Columns["CustomerId"].Visible = false;
            releasePermissionsDataGridView.Columns["Id"].Visible = false;
            releasePermissionsDataGridView.Columns["Items"].Visible = false;

            // Wire up all event handlers
            warehouseComboBox2.SelectedIndexChanged += WarehouseComboBox2_SelectedIndexChanged;
            additemComboBox1.SelectedIndexChanged += AdditemComboBox1_SelectedIndexChanged;
            createreleasepermButton2.Click += CreatereleasepermButton2_Click;
            crownButton1.Click += addItemButton1_Click;

            // Clear any previous items
            releasePermissionItems.Clear();
            // additemcurrentsupplyTextBox1.Clear();
        }

        private void WarehouseComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (warehouseComboBox2.SelectedValue != null)
            {
                int warehouseId = (int)warehouseComboBox2.SelectedValue;
                LoadAvailableItems(warehouseId);
                
                // Clear everything when warehouse changes
                releasePermissionItems.Clear();
                additemcurrentsupplyTextBox1.Text = "";
            }
        }

        private void AdditemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (warehouseComboBox2.SelectedValue != null && additemComboBox1.SelectedValue != null)
            {
                int warehouseId = (int)warehouseComboBox2.SelectedValue;
                int itemId = (int)additemComboBox1.SelectedValue;

                var currentStock = _context.WarehouseItems
                    .Where(wi => wi.WarehouseId == warehouseId && wi.ItemId == itemId)
                    .Select(wi => wi.Quantity)
                    .FirstOrDefault();

                additemcurrentsupplyTextBox1.Text = $"Current Stock: {currentStock}";
            }
        }

        private void CreatereleasepermButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(releasePermissionNumberTextBox.Text))
                {
                    MessageBox.Show("Please enter a permission number.");
                    return;
                }

                if (releasePermissionItems.Count == 0)
                {
                    MessageBox.Show("Please add at least one item.");
                    return;
                }

                var releasePermission = new ReleasePermission
                {
                    PermissionNumber = releasePermissionNumberTextBox.Text,
                    PermissionDate = relasePermissionDateDateTime.Value,
                    WarehouseId = (int)warehouseComboBox2.SelectedValue,
                    CustomerId = (int)customerComboBox2.SelectedValue,
                    Items = releasePermissionItems
                };

                // Update warehouse items quantities
                foreach (var item in releasePermissionItems)
                {
                    var warehouseItem = _context.WarehouseItems
                        .FirstOrDefault(wi => wi.WarehouseId == releasePermission.WarehouseId &&
                                            wi.ItemId == item.ItemId);

                    if (warehouseItem != null)
                    {
                        if (warehouseItem.Quantity >= item.Quantity)
                        {
                            warehouseItem.Quantity -= item.Quantity;
                        }
                        else
                        {
                            MessageBox.Show($"Not enough stock for item {item.ItemId}. Available: {warehouseItem.Quantity}");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Item {item.ItemId} not found in warehouse {releasePermission.WarehouseId}");
                        return;
                    }
                }

                _context.ReleasePermissions.Add(releasePermission);
                _context.SaveChanges();

                // Clear the items list and update UI
                releasePermissionItems.Clear();
                addItemQuantityTextBox2.Clear();
                MessageBox.Show("Release Permission Added Successfully!");

                // Refresh the grids
                SetupReleasePermissionsTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating release permission: {ex.Message}");
            }
        }

        private void addItemButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(addItemQuantityTextBox2.Text))
                {
                    MessageBox.Show("Please enter a quantity.");
                    return;
                }

                int quantity = int.Parse(addItemQuantityTextBox2.Text);
                string currentText = additemcurrentsupplyTextBox1.Text;
                int currentStock = int.Parse(currentText.Replace("Current Stock: ", ""));

                if (quantity > currentStock)
                {
                    MessageBox.Show("Cannot release more items than available in stock.");
                    return;
                }

                var releasePermissionItem = new ReleasePermissionItem
                {
                    ItemId = (int)additemComboBox1.SelectedValue,
                    Quantity = quantity
                };

                releasePermissionItems.Add(releasePermissionItem);

                dynamic selected = additemComboBox1.SelectedItem;
                string selectedText = selected.Name;

                // Show the list of added items
                StringBuilder itemsList = new StringBuilder();
                itemsList.AppendLine("Added Items:");
                foreach (var item in releasePermissionItems)
                {
                    var itemName = _context.Items.First(i => i.Id == item.ItemId).Name;
                    itemsList.AppendLine($"{itemName} : {item.Quantity}");
                }
                additemcurrentsupplyTextBox1.Text = itemsList.ToString();
                
                // Clear the quantity textbox for next item
                addItemQuantityTextBox2.Clear();
                
                MessageBox.Show($"Added {quantity} of {selectedText}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}");
            }
        }
        #endregion


        #region Reports Tab
        private void SetupReportsTab()
        {
            // Create report type selection
            var reportTypeCombo = new ReaLTaiizor.Controls.PoisonComboBox
            {
                Location = new Point(20, 20),
                Width = 200,
                Items = { 
                    "Warehouse Report",
                    "Item Report",
                    "Item Movement Report",
                    "Expired Items Report",
                    "Expiring Soon Report"
                }
            };
            tabPage12.Controls.Add(reportTypeCombo);

            // Create warehouse selection
            var warehouseLabel = new Label { Text = "Warehouse:", Location = new Point(20, 60) };
            var warehouseCombo = new ReaLTaiizor.Controls.PoisonComboBox
            {
                Location = new Point(20, 80),
                Width = 200,
                Name = "reportsWarehouseCombo"
            };
            
            // Create date range selection
            var dateFromLabel = new Label { Text = "From Date:", Location = new Point(20, 120) };
            var dateFromPicker = new ReaLTaiizor.Controls.PoisonDateTime
            {
                Location = new Point(20, 140),
                Width = 200,
                Name = "reportsDateFrom",
                Format = DateTimePickerFormat.Short
            };

            var dateToLabel = new Label { Text = "To Date:", Location = new Point(240, 120) };
            var dateToPicker = new ReaLTaiizor.Controls.PoisonDateTime
            {
                Location = new Point(240, 140),
                Width = 200,
                Name = "reportsDateTo",
                Format = DateTimePickerFormat.Short
            };

            // Create generate button
            var generateButton = new ReaLTaiizor.Controls.PoisonButton
            {
                Text = "Generate Report",
                Location = new Point(20, 180),
                Width = 120
            };

            // Create results grid
            var resultsGrid = new ReaLTaiizor.Controls.PoisonDataGridView
            {
                Location = new Point(20, 220),
                Width = tabPage12.Width - 40,
                Height = tabPage12.Height - 240,
                Name = "reportsGrid",
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Load warehouses
            var warehouses = _context.Warehouses.Select(w => new { w.Id, w.Name }).ToList();
            warehouseCombo.DataSource = warehouses;
            warehouseCombo.DisplayMember = "Name";
            warehouseCombo.ValueMember = "Id";

            // Add controls to tab
            tabPage12.Controls.AddRange(new Control[] {
                warehouseLabel, warehouseCombo,
                dateFromLabel, dateFromPicker,
                dateToLabel, dateToPicker,
                generateButton, resultsGrid
            });

            // Wire up events
            reportTypeCombo.SelectedIndexChanged += (s, e) => UpdateReportControls(reportTypeCombo.SelectedItem.ToString());
            generateButton.Click += GenerateReport;
        }

        private void UpdateReportControls(string reportType)
        {
            var warehouseCombo = tabPage12.Controls["reportsWarehouseCombo"] as ReaLTaiizor.Controls.PoisonComboBox;
            
            switch (reportType)
            {
                case "Warehouse Report":
                    warehouseCombo.Visible = true;
                    break;
                case "Item Report":
                case "Item Movement Report":
                    warehouseCombo.Visible = true;
                    // Add multi-select capability for warehouses
                    break;
                case "Expired Items Report":
                case "Expiring Soon Report":
                    warehouseCombo.Visible = true;
                    break;
            }
        }

        private void GenerateReport(object sender, EventArgs e)
        {
            var reportTypeCombo = tabPage12.Controls.OfType<ReaLTaiizor.Controls.PoisonComboBox>().First();
            var warehouseCombo = tabPage12.Controls["reportsWarehouseCombo"] as ReaLTaiizor.Controls.PoisonComboBox;
            var dateFrom = (tabPage12.Controls["reportsDateFrom"] as ReaLTaiizor.Controls.PoisonDateTime).Value;
            var dateTo = (tabPage12.Controls["reportsDateTo"] as ReaLTaiizor.Controls.PoisonDateTime).Value;
            var resultsGrid = tabPage12.Controls["reportsGrid"] as ReaLTaiizor.Controls.PoisonDataGridView;

            switch (reportTypeCombo.SelectedItem.ToString())
            {
                case "Warehouse Report":
                    GenerateWarehouseReport(warehouseCombo.SelectedValue as int?, dateFrom, dateTo, resultsGrid);
                    break;
                case "Item Report":
                    GenerateItemReport(warehouseCombo.SelectedValue as int?, dateFrom, dateTo, resultsGrid);
                    break;
                case "Item Movement Report":
                    GenerateItemMovementReport(warehouseCombo.SelectedValue as int?, dateFrom, dateTo, resultsGrid);
                    break;
                case "Expired Items Report":
                    GenerateExpiredItemsReport(warehouseCombo.SelectedValue as int?, resultsGrid);
                    break;
                case "Expiring Soon Report":
                    GenerateExpiringSoonReport(warehouseCombo.SelectedValue as int?, resultsGrid);
                    break;
            }
        }

        private void GenerateWarehouseReport(int? warehouseId, DateTime fromDate, DateTime toDate, DataGridView grid)
        {
            if (!warehouseId.HasValue) return;

            var query = _context.WarehouseItems
                .Include(wi => wi.Item)
                .Include(wi => wi.Warehouse)
                .Where(wi => wi.WarehouseId == warehouseId)
                .Select(wi => new
                {
                    ItemName = wi.Item.Name,
                    ItemCode = wi.Item.Code,
                    Quantity = wi.Quantity,
                    ProductionDate = wi.ProductionDate,
                    ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays)
                })
                .ToList();

            grid.DataSource = query;
        }

        private void GenerateItemReport(int? warehouseId, DateTime fromDate, DateTime toDate, DataGridView grid)
        {
            var query = _context.WarehouseItems
                .Include(wi => wi.Item)
                .Include(wi => wi.Warehouse)
                .AsQueryable();

            if (warehouseId.HasValue)
                query = query.Where(wi => wi.WarehouseId == warehouseId);

            var result = query.Select(wi => new
            {
                WarehouseName = wi.Warehouse.Name,
                ItemName = wi.Item.Name,
                ItemCode = wi.Item.Code,
                Quantity = wi.Quantity,
                ProductionDate = wi.ProductionDate,
                ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays)
            })
            .ToList();

            grid.DataSource = result;
        }

        private void GenerateItemMovementReport(int? warehouseId, DateTime fromDate, DateTime toDate, DataGridView grid)
        {
            var supplyMovements = _context.SupplyPermissions
                .Include(sp => sp.Items)
                .ThenInclude(si => si.Item)
                .Where(sp => sp.PermissionDate >= fromDate && sp.PermissionDate <= toDate)
                .SelectMany(sp => sp.Items.Select(si => new
                {
                    Date = sp.PermissionDate,
                    ItemName = si.Item.Name,
                    Type = "Supply",
                    Quantity = si.Quantity
                }));

            var releaseMovements = _context.ReleasePermissions
                .Include(rp => rp.Items)
                .ThenInclude(ri => ri.Item)
                .Where(rp => rp.PermissionDate >= fromDate && rp.PermissionDate <= toDate)
                .SelectMany(rp => rp.Items.Select(ri => new
                {
                    Date = rp.PermissionDate,
                    ItemName = ri.Item.Name,
                    Type = "Release",
                    Quantity = -ri.Quantity
                }));

            var allMovements = supplyMovements.Union(releaseMovements)
                .OrderBy(m => m.Date)
                .ToList();

            grid.DataSource = allMovements;
        }

        private void GenerateExpiredItemsReport(int? warehouseId, DataGridView grid)
        {
            var today = DateTime.Today;
            var query = _context.WarehouseItems
                .Include(wi => wi.Item)
                .Include(wi => wi.Warehouse)
                .Where(wi => wi.ProductionDate.AddDays(wi.ExpiryDateInDays) < today);

            if (warehouseId.HasValue)
                query = query.Where(wi => wi.WarehouseId == warehouseId);

            var result = query.Select(wi => new
            {
                WarehouseName = wi.Warehouse.Name,
                ItemName = wi.Item.Name,
                ItemCode = wi.Item.Code,
                Quantity = wi.Quantity,
                ProductionDate = wi.ProductionDate,
                ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays),
                DaysExpired = (today - wi.ProductionDate.AddDays(wi.ExpiryDateInDays)).Days
            })
            .ToList();

            grid.DataSource = result;
        }

        private void GenerateExpiringSoonReport(int? warehouseId, DataGridView grid)
        {
            var today = DateTime.Today;
            var thirtyDaysFromNow = today.AddDays(30); // Items expiring in next 30 days

            var query = _context.WarehouseItems
                .Include(wi => wi.Item)
                .Include(wi => wi.Warehouse)
                .Where(wi => 
                    wi.ProductionDate.AddDays(wi.ExpiryDateInDays) > today && 
                    wi.ProductionDate.AddDays(wi.ExpiryDateInDays) <= thirtyDaysFromNow);

            if (warehouseId.HasValue)
                query = query.Where(wi => wi.WarehouseId == warehouseId);

            var result = query.Select(wi => new
            {
                WarehouseName = wi.Warehouse.Name,
                ItemName = wi.Item.Name,
                ItemCode = wi.Item.Code,
                Quantity = wi.Quantity,
                ProductionDate = wi.ProductionDate,
                ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays),
                DaysUntilExpiry = (wi.ProductionDate.AddDays(wi.ExpiryDateInDays) - today).Days
            })
            .ToList();

            grid.DataSource = result;
        }
        #endregion

        const int DWMWA_CAPTION_COLOR = 35;

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);




        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void hopeTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void saveSuppliers_Click(object sender, EventArgs e)
        {

            _context.SaveChanges();
            MessageBox.Show("Supplier Added/Edited Succesfully!");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (Supplier)suppliersGridView.CurrentRow.DataBoundItem;
            Supplypermissions modalForm = new Supplypermissions(selectedSupplier);
            modalForm.ShowDialog();
        }

        private void suppliersDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = suppliersGridView.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0) // Ensure click is on a row
                {
                    suppliersGridView.ClearSelection(); // Deselect all rows
                    suppliersGridView.Rows[hit.RowIndex].Selected = true; // Select the right-clicked row
                    suppliersGridView.CurrentCell = suppliersGridView.Rows[hit.RowIndex].Cells[0]; // Set focus

                    contextMenuStrip2.Show(suppliersGridView, e.Location); // Show context menu
                }
            }
        }





        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (Supplier)suppliersGridView.CurrentRow.DataBoundItem;
            Supplypermissions modalForm = new Supplypermissions(selectedSupplier);
            modalForm.ShowDialog();
        }



        private void crownDockPanel1_Load(object sender, EventArgs e)
        {

        }

        private void LoadAvailableItems(int warehouseId)
        {
            var warehouseItems = _context.WarehouseItems
                .Include(wi => wi.Item)
                .Where(wi => wi.WarehouseId == warehouseId)
                .Select(wi => new
                {
                    wi.ItemId,
                    wi.Item.Name,
                    wi.Item.Code,
                    wi.Quantity,
                    wi.ProductionDate,
                    ExpiryDate = wi.ProductionDate.AddDays(wi.ExpiryDateInDays)
                })
                .ToList();

            availableItemsDataGridView1.DataSource = warehouseItems;
        }

    }
}
