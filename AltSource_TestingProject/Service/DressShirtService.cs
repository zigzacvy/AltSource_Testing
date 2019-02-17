using AltSource_TestingProject.Model;
using System;
using System.Linq;

namespace AltSource_TestingProject.Service
{
    public class DressShirtService:IBaseService<DressShirt>
    {
        private DataSeed.DataSeed _dataSeed;
        public DressShirtService(DataSeed.DataSeed dataSeed)
        {
            _dataSeed = dataSeed;
        }
        public bool Sell(DressShirt dShirt, int quanlity)
        {
            try
            {
                if (dShirt.Quanlity <= 0)
                {
                    Console.WriteLine("This dressshirt sold out!!!");
                    return false;
                }
                if (dShirt.Quanlity < quanlity)
                {
                    Console.WriteLine("This dressshirt doesn't enough to sell");
                    return false;
                }

                dShirt.Quanlity -= quanlity;
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Buy(int quanlity, Enum color, Enum size)
        {
            try
            {
                int id = _dataSeed.DressShirts.Count + 1;
                var dShirt = new DressShirt
                {
                    Id = id,
                    Color = (Color) color,
                    Size = (Size) size, 
                    Quanlity = quanlity, 
                    BuyPrice = 8,
                    SellPrice = 20
                };
                 
                _dataSeed.DressShirts.Add(dShirt);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public DressShirt FindById(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Cannot find TShirt");
                    return null;
                }

                DressShirt data = _dataSeed.DressShirts.SingleOrDefault(dshirt => dshirt.Id == Int32.Parse(id));
                if (data == null)
                {
                    Console.WriteLine("Cannot find DressShirt");
                    return null;
                }

                return data;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}