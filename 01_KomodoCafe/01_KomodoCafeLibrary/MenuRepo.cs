using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeLibrary
{
    public class MenuRepo
    {
        public List<Menu> _menu = new List<Menu>();

        public void AddItemsToMenu(Menu item)
        {
            _menu.Add(item);
        }

        public List<Menu> GetAllOfMenu()
        {
            return _menu;
        }

        public bool UpdateMenuItem(int firstItem, Menu newItem)
        {
            Menu oldItem = GetMenuItemByNumber(firstItem);

            if(oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
            }
            return false;
        }

        private Menu GetMenuItemByNumber(int menuNumber)
        {
            foreach (Menu item in _menu)
            {
                if (item.MealNumber == menuNumber)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Menu> MenuList()
        {
            return _menu;
        }

        public bool RemoveMenuItems(Menu item)
        {
            return _menu.Remove(item);
        }

        public bool RemoveItemByNumber(int mealNumber)
        {
            Menu mealNumberDelete = GetMenuItemByNumber(mealNumber);

            return RemoveMenuItems(mealNumberDelete);
        }
    }
}
