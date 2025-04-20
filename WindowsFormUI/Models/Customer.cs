using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        
        public virtual ICollection<ReleasePermission> ReleasePermissions { get; set; }
    }
} 