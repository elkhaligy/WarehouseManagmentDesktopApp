using System;

namespace WarehouseManagement.Models
{
    public class ItemTransfer : BaseEntity
    {
        // ItemTransfer [Id (PK), SourceWarehouseId (FK), DestinationWarehouseId (FK), ItemId (FK), Quantity, TransferDate, ProductionDate, ExpiryDate]
        public int SourceWarehouseId { get; set; }
        public virtual Warehouse SourceWarehouse { get; set; }
        
        public int DestinationWarehouseId { get; set; }
        public virtual Warehouse DestinationWarehouse { get; set; }
        
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public int Quantity { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
} 