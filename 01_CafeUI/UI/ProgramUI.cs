using _01_CafeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI.UI
{
    class ProgramUI
    {
        private readonly CafeRepo _cafeRepo = new CafeRepo();
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {

                Console.WriteLine("Hello Menu Manager, would you like to:\n" +
                    "1. Create New Menu Item\n" +
                    "2. Delete Current Menu Item\n" +
                    "3. View All Menu Items\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        // DeleteCurrentMenuItem();
                        break;
                    case "3":
                        DisplayAll();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateMenuItem()
        {
            MenuItem newItem = new MenuItem();

            int tempMenuItem = 0;
            bool numberNeed = true;
            while (numberNeed)
            {
                Console.WriteLine("Please Enter a Meal Number");
                string userID = Console.ReadLine();
                int id;
                Int32.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    tempMenuItem = id;
                    numberNeed = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            newItem.MealNumber = tempMenuItem;

            Console.WriteLine("\nWhat is the name of the meal?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("\nGive it a description:");
            newItem.Description = Console.ReadLine();

            List<string> ingredToAdd = new List<string>();
            bool moreIngred = true;
            while (moreIngred)
            {
                Console.WriteLine("\nWrite an ingredient this item needs: ");
                ingredToAdd.Add(Console.ReadLine());

                bool moreQuestion = true;
                while (moreQuestion)
                {
                    Console.WriteLine("\nAny other ingredients? (y/n)");
                    string moreInput = Console.ReadLine();
                    switch (moreInput)
                    {
                        case "y":
                            moreQuestion = false;
                            break;
                        case "n":
                            moreIngred = false;
                            moreQuestion = false;
                            break;
                        default:
                            Console.WriteLine("Please type y or n");
                            break;
                    }
                }
            }
            newItem.Ingredients = ingredToAdd;

            float tempMenuPrice = 0f;
            bool needNumber = true;
            while (needNumber)
            {
                Console.WriteLine("Please Enter a Price");
                string userID = Console.ReadLine();
                float id;
                float.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    tempMenuPrice = id;
                    needNumber = false;
                }
            }

            newItem.Price = tempMenuPrice;

            _cafeRepo.AddMenuItemToRepository(newItem);
        }

        private void DisplayAll()
        {
            Console.WriteLine("Meal Number\tMeal Name\tDescription\tPrice\tIngredients");
            List<MenuItem> currentList = _cafeRepo.GetAllMenuItems();
            foreach (MenuItem current in currentList)
            {
                Console.WriteLine($"{current.MealNumber}\t{current.MealName}\t{current.Description}\t{current.Price}\t");
                foreach(string ingredient in current.Ingredients)
                {
                    Console.Write($"{ingredient}, ");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
