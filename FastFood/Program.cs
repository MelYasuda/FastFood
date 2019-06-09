using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{

    class Program
    {
        static void Main(string[] args)
        {
            // Single Item logic with Factory Method pattern 
            SingleItem hamburger = Hamburger.CreateHamburger();
            SingleItem fries = Fries.CreateFries();
            SingleItem soda = Soda.CreateSoda();

            List<dynamic> Menu = new List<dynamic>
            {
                hamburger,
                fries,
                soda
            };

            // Combo logic with Builder Pattern
            ComboBuilder builder;
            ComboMenu comboMenu = new ComboMenu();
            Dictionary<string, dynamic> combo;
            List<Dictionary<string, dynamic>> ComboList = new List<Dictionary<string, dynamic>>();


            builder = new CheeseBurgerComboBuilder();
            comboMenu.Construct(builder);
            combo = builder.combo.GetCombo();
            Menu.Add(combo);

            builder = new FishBurgerComboBuilder();
            comboMenu.Construct(builder);
            combo = builder.combo.GetCombo();
            Menu.Add(combo);

            for (var i = 0; i < Menu.Count; i++)
            {
                if(Menu[i] is SingleItem)
                    Console.WriteLine("Item number: {0}. Item: {1} Price: ${2} Calories: {3}", i + 1, Menu[i].ItemName, Menu[i].Price, Menu[i].Calories);
                else
                {
                    int number = i + 1;
                    Console.WriteLine("\n---------------------------");
                    Console.WriteLine("Item number: " + number);
                    Console.WriteLine("Combo: {0}", Menu[i]["ComboType"]);
                    Console.WriteLine("Sandwitch: {0}", Menu[i]["Sandwitch"]);
                    Console.WriteLine("Sides: {0}", Menu[i]["Sides"]);
                    Console.WriteLine("Soda: {0}", Menu[i]["Soda"]);
                    Console.WriteLine("Price: ${0}", Menu[i]["Price"]);
                }
            }


            Console.WriteLine("Select an item or a combo from the menu by typing the item number(if multipe, divide by commas with no sp) and press Enter to proceed to check out");

            var input = Console.ReadLine();
            input = input.ToLower();

            List<dynamic> cart = new List<dynamic>();
            Price price = new Price();

            //Get rid of spaces...
            string[] arr = input.Split(',');
                foreach(string item in arr)
                {
                    int num = int.Parse(item);
                    if (Menu.Count<num)
                    {
                    Console.WriteLine("Type the correct value");
                    }
                    else
                    {
                        cart.Add(Menu[num - 1]);
                    }

                }
                for (var i = 0; i < cart.Count; i++)
                {
                    // if combo, print out dictionary
                    if(cart[i] is SingleItem)
                    {
                    price.AddPrice(cart[i].Price);
                    Console.WriteLine("Item: {0}, Price: ${1}", cart[i].ItemName, cart[i].Price);
                    }
                    else
                    {
                    price.AddPrice(cart[i]["Price"]);
                    Console.WriteLine("Combo: {0}, Price: ${1}", cart[i]["ComboType"], cart[i]["Price"]);
                    }
                }

                Console.WriteLine("Your total is ${0}", price.TotalPrice());

                Console.WriteLine("Press Enter to check out");
                Console.ReadLine();
                Console.WriteLine("Thank you!");

                //Logging process
                Logger.GetLogger().WriteMessage("----------------------------------------");
                Logger.GetLogger().WriteMessage(DateTime.Now);
                Logger.GetLogger().WriteMessage("Total Transaction: $" + price.TotalPrice());

                for (var i = 0; i < cart.Count; i++)
                {
                    if (cart[i] is SingleItem)
                    {
                    Logger.GetLogger().WriteMessage("Item:" + cart[i].ItemName + " " + "Price: $" + cart[i].Price);
                    }
                    else
                    {
                    Logger.GetLogger().WriteMessage("Combo Type:" + cart[i]["ComboType"] + " " + "Price:" + cart[i]["Price"]);
                }
                    }
        }
    }

    //public class Price
    //{
    //    public static List<double> Prices = new List<double>();

    //    public void AddPrice(double price)
    //    {
    //        Prices.Add(price);
    //    }

    //    public double TotalPrice()
    //    {
    //        return Prices.ConvertAll(Convert.ToDouble).Sum();
    //    }
    //}
}
