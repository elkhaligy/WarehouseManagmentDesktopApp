using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Item : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }

        // Navigation properties
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
        public virtual ICollection<SupplyPermissionItem> SupplyPermissionItems { get; set; }
        public virtual ICollection<ReleasePermissionItem> ReleasePermissionItems { get; set; }
        public virtual ICollection<ItemTransfer> ItemTransfers { get; set; }
    }
} 


// Warehouse [Id, Name, Address, ResponsiblePerson, Phone, Email]
// Item [Id, Code, Name, UnitOfMeasurement]
// WarehouseItem [Id (PK), WarehouseId (FK), ItemId (FK), SupplierId (FK), Quantity, ProductionDate, ExpiryDate]
// Supplier [Id, Name, Phone, Email]
// SupplyPermission [Id, SupplierId (FK), ItemId (FK), Quantity, ProductionDate, ExpiryDate]
// ReleasePermission [Id, CustomerId (FK), ItemId (FK), Quantity, ProductionDate, ExpiryDate]
// ItemTransfer [Id (PK), SourceWarehouseId (FK), DestinationWarehouseId (FK), ItemId (FK), Quantity, TransferDate, ProductionDate, ExpiryDate]

