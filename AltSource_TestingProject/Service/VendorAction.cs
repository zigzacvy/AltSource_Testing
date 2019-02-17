using System;
using AltSource_TestingProject.Model;
 using System.Linq;
 namespace AltSource_TestingProject.Service
 {
     public  class VendorAction : IVendorAction
     {
         private readonly DataSeed.DataSeed _dataSeed;
         public VendorAction(DataSeed.DataSeed dataSeed)
         {
             _dataSeed = dataSeed;
         }  
         public int SellClothes(Guid Id, int quanlity, string typeClothes)
         {
             try
             {
                 Clothes data = null;
                 if (typeClothes.Equals("TShirt"))
                 {
                     data =   _dataSeed.TShirts.SingleOrDefault(tShirt => tShirt.Id.Equals(Id));
                     
                 }
                 else
                 {
                     data =  _dataSeed.DressShirts.SingleOrDefault(tShirt => tShirt.Id.Equals(Id));
                 }
                 if (data == null)
                 {
                     Console.WriteLine("Can not find clothes");
                     return 0;
                 }

                 if (data.Quanlity < quanlity)
                 {
                     Console.WriteLine("You can not buy quanlity to large.");
                     return 0;
                 }

                 data.Quanlity -= quanlity;
                 return 1;

             }
             catch (Exception e)
             {
                 Console.WriteLine(e.StackTrace);
                 return 0;
             }
         }
 
         public int BuyClothes(Clothes clothes)
         {
             try
             {
                
                     if (clothes.GetType() == typeof(TShirt))
                     {
                         _dataSeed.TShirts.Add((TShirt)clothes);
                     }
                     else
                     {
                         _dataSeed.DressShirts.Add((DressShirt) clothes);
                     }

                 return 1;

             }
             catch (Exception e)
             {
                 Console.WriteLine(e.StackTrace);
                 return 0;
             }
            
         }
     }
 }