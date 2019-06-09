using System;
using System.Collections.Generic;

namespace FastFood
{
    public class SingleItem
    {
        public string ItemName { get; private set; }
        public double Price { get; private set; }
        public int Calories { get; private set; }

        private SingleItem(string itemName, double price, int calories)
        {
            ItemName = itemName;
            Price = price;
            Calories = calories;
        }

        public static SingleItem CreateNewSingleItem(string itemName, double price, int calories)
        {

            return new SingleItem(itemName, price, calories);
        }
    }

    class Hamburger
    {
        public static SingleItem CreateHamburger()
        {
            return SingleItem.CreateNewSingleItem("Hamburger", 4, 350);
        }
    }

    class CheeseBurger
    {
        public static SingleItem CreateCheeseBurger()
        {
            return SingleItem.CreateNewSingleItem("Cheese Burger", 4, 400);
        }
    }

    class Fries
    {
        public static SingleItem CreateFries()
        {
            return SingleItem.CreateNewSingleItem("Fries", 3, 350);
        }
    }

    class Soda
    {
        public static SingleItem CreateSoda()
        {
            return SingleItem.CreateNewSingleItem("Soda", 1, 350);
        }
    }

}
