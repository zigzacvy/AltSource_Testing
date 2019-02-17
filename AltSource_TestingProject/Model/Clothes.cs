using System;
using System.Data.SqlTypes;

namespace AltSource_TestingProject.Model
{
    public abstract class Clothes
    {
        public Guid Id { get; set; }
        public Color Color { get; set; }
        
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quanlity { get; set; }
        
        public  Size Size { get; set; }
    }
}