using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        
        public virtual ICollection<SupplyPermission> SupplyPermissions { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
} 