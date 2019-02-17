using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AltSource_TestingProject.Model;
using AltSource_TestingProject.DataSeed;
using AltSource_TestingProject.Service;

namespace AltSource_TestingProject
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var seedData = new DataSeed.DataSeed();
          //  var vendorService = new VendorAction(seedData);
            var tShirtService = new TShirtService(seedData);
            var  data = new DataSeed.DataSeed();


            DisplayData(data);
            
            Console.WriteLine("Do you buy or sell\nPlease type only sell or buy");
            var input = Console.ReadLine();
            if (input.Equals("buy"))
            {
                Console.WriteLine("Please type quanlity: ");
                string strquanlity = Console.ReadLine();
                int quanlity = Int32.Parse(strquanlity);
           
                Console.WriteLine("Please type type of Clothes: ");
                string typeClothes = Console.ReadLine();
                Console.WriteLine("Please type Size : ");
                string size = Console.ReadLine();
                Console.WriteLine("Please type Color : ");
                string color = Console.ReadLine();
                if (typeClothes.Equals("TShirt"))
                {
//                    var TShirt = new TShirt(){Quanlity = quanlity, };
//                    var result = _vendorService.BuyClothes()
                }
                
            }
            else if(input.Equals("sell"))
            {
                Console.WriteLine("Please type Id of TShirt : ");
                var tShirt = tShirtService.FindById(Console.ReadLine());
                Console.WriteLine("Please type quanlity to sell : ");
                var quanlity = Int32.Parse(Console.ReadLine());
                var result = tShirtService.Sell(tShirt, quanlity);


                // var result =   vendorService.SellClothes(new Guid(id),quanlity,typeClothes);
            }
            else
            {
                Console.WriteLine("Please type only sell or buy");
            }
        }

        private static void DisplayData(DataSeed.DataSeed data)
        {
            Console.WriteLine("------------- TShirt-------------");
            data.TShirts.ForEach(tShirt =>
                Console.WriteLine($"{tShirt.Id}, {tShirt.Quanlity}, {tShirt.Color}, {tShirt.Size}, {tShirt.BuyPrice}"));
            
            Console.WriteLine("------------- DressShirt-------------");
            data.DressShirts.ForEach(dShirt =>
                Console.WriteLine($"{dShirt.Id}, {dShirt.Quanlity}, {dShirt.Color}, {dShirt.Size}, {dShirt.BuyPrice}"));
            
        }
    }
    
    
    
    
}