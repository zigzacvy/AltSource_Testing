using System;
using System.Collections.Generic;
using AltSource_TestingProject.Model;

namespace AltSource_TestingProject.DataSeed
{
    public  class DataSeed
    {
        public DataSeed()
        {
            TShirts = new List<TShirt>()
            {
                new TShirt(){Id = Guid.NewGuid(),Color = Color.Black, SellPrice = 12, BuyPrice = 6, Size = Size.SizeS,Quanlity = 100},
                new TShirt(){ Id = Guid.NewGuid(),Color = Color.White, SellPrice = 12, BuyPrice = 6, Size = Size.SizeM, Quanlity = 100},
                new TShirt(){ Id = Guid.NewGuid(),Color = Color.Yellow, SellPrice = 12, BuyPrice = 6, Size = Size.SizeL, Quanlity = 100},
                new TShirt(){Id = Guid.NewGuid(),Color = Color.Red, SellPrice = 12, BuyPrice = 6, Size = Size.SizeS, Quanlity = 100}
                
            };
            DressShirts = new List<DressShirt>()
            {
                new DressShirt(){Id = Guid.NewGuid(), Color =  Color.Black, SellPrice = 20, BuyPrice =  8, Size = Size.SizeS, Quanlity = 100},
                new DressShirt(){Id = Guid.NewGuid(), Color =  Color.White, SellPrice = 20, BuyPrice =  8, Size = Size.SizeS, Quanlity = 100},
                new DressShirt(){Id = Guid.NewGuid(), Color =  Color.Yellow, SellPrice = 20, BuyPrice =  8, Size = Size.SizeS, Quanlity = 100},
                new DressShirt(){Id = Guid.NewGuid(), Color =  Color.Red, SellPrice = 20, BuyPrice =  8, Size = Size.SizeS, Quanlity = 100}
            };

        }
       public List<TShirt> TShirts { get; set; }
       public List<DressShirt> DressShirts { get; set; }
        
    }
}