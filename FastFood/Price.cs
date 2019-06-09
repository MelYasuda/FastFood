using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    public class Price
    {
        public static List<double> Prices = new List<double>();

        public void AddPrice(double price)
        {
            Prices.Add(price);
        }

        public double TotalPrice()
        {
            return Prices.ConvertAll(Convert.ToDouble).Sum();
        }
    }
}
