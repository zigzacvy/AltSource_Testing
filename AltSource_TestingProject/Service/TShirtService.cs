using System;
using AltSource_TestingProject.Model;
 using System.Linq;
 namespace AltSource_TestingProject.Service
 {
     public  class TShirtService : IBaseService<TShirt>
     {
         private readonly DataSeed.DataSeed _dataSeed;
         public TShirtService(DataSeed.DataSeed dataSeed)
         {
             _dataSeed = dataSeed;
         }  
         public bool Sell(TShirt tShirt, int quanlity)
         {
             try
             {
                 if (tShirt.Quanlity <= 0)
                 {
                     Console.WriteLine("This tshirt sold out!!!");
                     return false;
                 }
                 if (tShirt.Quanlity < quanlity)
                 {
                     Console.WriteLine("This tshirt doesn't enough to sell");
                     return false;
                 }

                 tShirt.Quanlity -= quanlity;
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
                 int id = _dataSeed.TShirts.Count + 1;
                 var tshirt = new TShirt
                 {
                     Id = id,
                     Color = (Color) color,
                     Size = (Size) size, 
                     Quanlity = quanlity, 
                     BuyPrice = 6,
                     SellPrice = 12
                 };
                 
                 _dataSeed.TShirts.Add(tshirt);
                 return true;

             }
             catch (Exception e)
             {
                 Console.WriteLine(e.StackTrace);
                 return false;
             }
         }

        
        
         public TShirt FindById(string id)
         {
             try
             {
                 if (String.IsNullOrEmpty(id))
                 {
                     Console.WriteLine("Cannot find TShirt");
                     return null;
                 }

                 TShirt data = _dataSeed.TShirts.SingleOrDefault(tshirt => tshirt.Id == Int32.Parse(id));
                 if (data == null)
                 {
                     Console.WriteLine("Cannot find TShirt");
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