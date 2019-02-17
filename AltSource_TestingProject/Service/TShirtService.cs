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

         public bool Buy(TShirt tShirt)
         {
             throw new NotImplementedException();
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

                 TShirt data = _dataSeed.TShirts.SingleOrDefault(tshirt => tshirt.Id.Equals(Guid.Parse(id)));
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