using _01_KomodoCafeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe
{
    public class ProgramUI
    {
        private bool _isRunning = true;

        public MenuRepo _menu = new MenuRepo();
        public void Run()
        {
            OpenMenu();
        }

        public void OpenMenu()
        {
            bool startingMenu = true;

            while (startingMenu && _isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Cafe, please make a selection from the menu below.\n" +
                                  "Select A Menu Option:\n" +
                                  "1. Show the entire menu selection\n" +
                                  "2. Add a menu item in\n" +
                                  "3. Remove an item from the menu\n" +
                                  "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetAllOfMenu();
                        break;
                    case "2":
                        AddItemsToMenu();
                        break;
                    case "3":
                        RemoveMenuItems();
                        break;
                    case "4":
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection, please enter a valid number");
                        break;
                }
            }
        }

        private void GetAllOfMenu()
        {
            Console.Clear();

            List<Menu> MealList = _menu.MenuList();

            foreach(Menu item in MealList)
            {
                Console.WriteLine("The menu contains the following items:\n" +
                                  $"{item.MealNumber}\n" +
                                  $"{item.MealNumber}\n" +
                                  $"{item.Description}\n" +
                                  $"{item.Ingredients}\n" +
                                  $"{item.Price}\n");
            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();
        }

        public void AddItemsToMenu()
        {
            Console.Clear();

            Console.WriteLine("To create a new meal item: \n" +
                              "Enter a meal number: ");

            int mealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a meal name: ");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter a description for the meal: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a list of ingredients: ");
            string ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price of the meal: ");

            double price = Convert.ToDouble(Console.ReadLine());

            Menu menuItem = new Menu(mealNumber, mealName, description, ingredients, price);

            _menu.AddItemsToMenu(menuItem);

        }

        private void RemoveMenuItems()
        {
            Console.Clear();

            Console.Write("Please enter the meal number you would like to delete: ");

            _menu.RemoveItemByNumber(Convert.ToInt32(Console.ReadLine()));

        }
    }
}
