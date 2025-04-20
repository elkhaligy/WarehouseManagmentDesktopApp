using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class ReleasePermission : BaseEntity
    {
        public string PermissionNumber { get; set; }
        public DateTime PermissionDate { get; set; }
        
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<ReleasePermissionItem> Items { get; set; }
    }

    public class ReleasePermissionItem : BaseEntity
    {
        public int ReleasePermissionId { get; set; }
        public virtual ReleasePermission ReleasePermission { get; set; }
        
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public int Quantity { get; set; }
    }
} 