using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AltSource_TestingProject.Model;
using AltSource_TestingProject.Service;

namespace AltSource_TestingProject
{
    internal class Program
    {
//        private IVendorAction _vendorService;
//        public Program(IVendorAction vendorService)
//        {
//            _vendorService = vendorService;
//        }
        public static void Main(string[] args)
        {
            var seedData = new DataSeed.DataSeed();
            var _vendorService = new VendorAction(seedData);
            var  data = new DataSeed.DataSeed();
            
            Console.WriteLine("------------- TShirt-------------");
            data.TShirts.ForEach(tShirt =>
                Console.WriteLine($"{tShirt.Id}, {tShirt.Quanlity}, {tShirt.Color}, {tShirt.Size}, {tShirt.BuyPrice}"));
            
            Console.WriteLine("------------- DressShirt-------------");
            data.DressShirts.ForEach(dShirt =>
                Console.WriteLine($"{dShirt.Id}, {dShirt.Quanlity}, {dShirt.Color}, {dShirt.Size}, {dShirt.BuyPrice}"));
            
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
                Console.WriteLine("Please type quanlity: ");
                string strquanlity = Console.ReadLine();
                int quanlity = Int32.Parse(strquanlity);
                Console.WriteLine("Please type Id: ");
                string id = Console.ReadLine();
                Console.WriteLine("Please type type of Clothes: ");
                string typeClothes = Console.ReadLine();
              var result =   _vendorService.SellClothes(new Guid(id),quanlity,typeClothes);
            }
            else
            {
                Console.WriteLine("Please type only sell or buy");
            }
        }
    }
    
}