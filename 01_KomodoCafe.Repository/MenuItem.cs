using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItem
    {
        static int _mealNumber = 1;

        public MenuItem()
        {
            MealNumber = _mealNumber++;
        }

        public MenuItem(string mealName, string description, List<string> ingredients, decimal price)
        {
            
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int MealNumber { get; private set; }
        

        public string MealName { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        public decimal Price { get; set; }
    }
}
