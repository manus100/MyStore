using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class CategoryConsts
    {
        public enum Categories
        {
            Beverages = 1,
            Condiments = 2,
            Confections = 3,
            Dairy = 4,
            Grains,
            Meat,
            Produce,
            Seafood
        }

        public const int Categoryid = (int)Categories.Beverages;
        public static string Categoryname = Categories.Beverages.ToString();
        public const string Description = "Category description test";

        public const int Categoryid2 = (int)Categories.Dairy;
        public static string Categoryname2 = Categories.Dairy.ToString();
        public const string Description2 = "Category description test2";
    }
}
