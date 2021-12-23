using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly List<MenuItem> _menuItems;

        public MenuItemRepository()
        {
            _menuItems = new List<MenuItem>();
        }

        public void CreateMenuItem(MenuItem menuItem)
        {
            
            
            _menuItems.Add(menuItem);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

       
        public MenuItem GetMenuItemByMenuNumber(int id)
        {
            var menuItem = _menuItems.FirstOrDefault(m => m.MealNumber == id);
            return menuItem;
        }
        public void DeleteMenuItem(int MenuID)
        {
            var itemToDelete = GetMenuItemByMenuNumber(MenuID);
            if (itemToDelete != null)
            {
                _menuItems.Remove(itemToDelete);
            }
            else
            {
                Console.WriteLine("Item does not exist.");
            }



        }
    }
}
