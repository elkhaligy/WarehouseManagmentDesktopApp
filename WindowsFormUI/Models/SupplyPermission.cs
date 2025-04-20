using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class SupplyPermission : BaseEntity
    {
        public string PermissionNumber { get; set; }
        public DateTime PermissionDate { get; set; }
        
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        
        public virtual ICollection<SupplyPermissionItem> Items { get; set; }
    }

    public class SupplyPermissionItem : BaseEntity
    {
        public int SupplyPermissionId { get; set; }
        public virtual SupplyPermission SupplyPermission { get; set; }
        
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public int ExpiryDurationInDays { get; set; }
    }
} 