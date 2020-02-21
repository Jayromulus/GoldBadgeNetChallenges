using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClasses
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(int number, string name, string desc, List<string> ingred, float price)
        {
            MealNumber = number;
            MealName = name;
            Description = desc;
            Ingredients = ingred;
            Price = price;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public float Price { get; set; }
    }
}
