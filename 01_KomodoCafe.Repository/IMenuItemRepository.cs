using System.Collections.Generic;

namespace _01_KomodoCafe.Repository
{
    public interface IMenuItemRepository
    {
        void CreateMenuItem(MenuItem menuItem);
        MenuItem GetMenuItemByMenuNumber(int id);
        void DeleteMenuItem(int MenuID);
        List<MenuItem> GetAllMenuItems();
    }
}