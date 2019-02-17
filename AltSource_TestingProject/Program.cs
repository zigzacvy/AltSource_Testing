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
           
            var  data = new DataSeed.DataSeed();
            var tShirtService = new TShirtService(data);
            var dShirtService = new DressShirtService(data);


            DisplayData(data);
            
            Console.WriteLine("Do you buy or sell, Please type only sell or buy");
            var input = Console.ReadLine();
            if (input.Equals("buy"))
            {
                Console.WriteLine("Do you want to buy TShirt or DressShirt\nPlease type t or d");
                var typeOfClothes = Console.ReadLine().Trim().ToUpper();
                if (typeOfClothes.Equals("T"))
                {
                    BuyTShirt(tShirtService);
                }
                DisplayData(data);
            }
            else if(input.Equals("sell"))
            {
                Console.WriteLine("Do you want to sell TShirt or DressShirt\nPlease type t or d");
                var typeOfClothes = Console.ReadLine().Trim().ToUpper();

                if (typeOfClothes.Equals("T"))
                {
                    SellTShirt(tShirtService);
                }
                else if(typeOfClothes.Equals("D"))
                {
                    SellDressShirt(dShirtService);
                }
               
                DisplayData(data);
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

        private static void SellTShirt(IBaseService<TShirt> tShirtService)
        {
            Console.WriteLine("Please type Id of TShirt : ");
            var tShirt = tShirtService.FindById(Console.ReadLine());
            if (tShirt == null)
            {
                return;
                
            }
            Console.WriteLine("Please type quanlity to sell : ");
            var quanlity = Int32.Parse(Console.ReadLine());
            var result = tShirtService.Sell(tShirt, quanlity);
           
        }
        
        private static void BuyTShirt(IBaseService<TShirt> tShirtService)
        {
            Console.WriteLine("Please type quanlity of TShirt : ");
            int quanlity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please type Color of TShirt(R: Red, B: Black, Y: Yellow, W: White)");
            string color = Console.ReadLine();
            Console.WriteLine("Please type Size of TShirt(S, M, L)");
            string size = Console.ReadLine();


            var result = tShirtService.Buy(quanlity,ConvertColor(color), ConvertSize(size));


        }
        
        private static void BuyDressShirt(IBaseService<DressShirt> dShirtService)
        {
            Console.WriteLine("Please type quanlity of DressShirt : ");
            int quanlity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please type Color of DressShirt(R: Red, B: Black, Y: Yellow, W: White)");
            string color = Console.ReadLine();
            Console.WriteLine("Please type Size of DressShirt(S, M, L)");
            string size = Console.ReadLine();


            var actionToBuy = dShirtService.Buy(quanlity,ConvertColor(color), ConvertSize(size));
            if (actionToBuy == false)
            {
                Console.WriteLine("Some thing wrong to buy");
            }
            else
            {
                Console.WriteLine("Thanks you");
            }


        }
        
        private static void SellDressShirt(IBaseService<DressShirt> dShirtService)
        {
            Console.WriteLine("Please type Id of DressShirt : ");
            var dShirt = dShirtService.FindById(Console.ReadLine());
            if (dShirt == null)
            {
                return;
            }
            Console.WriteLine("Please type quanlity to sell : ");
            var quanlity = Int32.Parse(Console.ReadLine());
            var actionToBuy = dShirtService.Sell(dShirt, quanlity);
            if (actionToBuy == false)
            {
                Console.WriteLine("Some thing wrong to buy");
            }
            else
            {
                Console.WriteLine("Thanks you");
            }
           
        }

        private static Enum ConvertSize(string size)
        {
            switch (size.Trim().ToUpper())
            {
                    case "S":
                        return Size.SizeS;
                    case "M":
                        return Size.SizeM;
                    default:
                        return Size.SizeL;
            }
        }
        
        
        private static Enum ConvertColor(string color)
        {
            switch (color.Trim().ToUpper())
            {
                case "R":
                    return Color.Red;
                case "B":
                    return Color.Black;
                case "Y":
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }
        
    }
    
    
    
    
}