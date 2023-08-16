using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    class Product
    {
        Guid id = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityInHand { get; set; }
        public int QuantitySold { get; set; }
        public double InventoryValue { get { return Price * QuantityInHand; } }
        public double SalesValue { get { return Price * QuantitySold; } }
        public int Remain { get { return QuantityInHand - QuantitySold; } }
        public int ReorderThreshold { get; set; }
        public bool ReorderStatus { get { if (Remain > ReorderThreshold) return false; else return true; } }

    }
}
