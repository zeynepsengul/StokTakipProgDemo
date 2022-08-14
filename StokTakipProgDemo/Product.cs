using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipProgDemo
{
    public delegate void StockControl();
    public class Product
    { 
        //public event StockControl StockControlEvent;
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitinStock { get; set; }
        public int CategoryId { get; set; }
    }
}
