using Realms;
using System;


namespace InventoryManagementSystem.Models
{
    public partial class Product : RealmObject
    {
        [PrimaryKey]
        public Guid ID { get; set; } = Guid.NewGuid();
        [Indexed(IndexType.General)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityInHand { get; set; }
        public int QuantitySold { get; set; }

        [Ignored]
        public double InventoryValue { get { return Price * QuantityInHand; } }
        [Ignored]
        public double SalesValue { get { return Price * QuantitySold; } }
        [Ignored]
        public int Remain { get { return QuantityInHand - QuantitySold; } }

        public int ReorderThreshold { get; set; }
        [Ignored]
        public bool ReorderStatus { get { if (Remain > ReorderThreshold) return false; else return true; } }

    }
}
