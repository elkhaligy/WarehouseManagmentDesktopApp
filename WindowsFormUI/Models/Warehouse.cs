using System.Collections.Generic;
using System;

namespace WarehouseManagement.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ResponsiblePerson { get; set; }

        // Navigation properties
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
        public virtual ICollection<SupplyPermission> SupplyPermissions { get; set; }
        public virtual ICollection<ReleasePermission> ReleasePermissions { get; set; }
        public virtual ICollection<ItemTransfer> SourceTransfers { get; set; }
        public virtual ICollection<ItemTransfer> DestinationTransfers { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class WarehouseItem : BaseEntity
    {
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        // WarehouseItem [Id (PK), WarehouseId (FK), ItemId (FK), SupplierId (FK), Quantity, ProductionDate, ExpiryDate]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public int ExpiryDateInDays { get; set; }
    }


} 