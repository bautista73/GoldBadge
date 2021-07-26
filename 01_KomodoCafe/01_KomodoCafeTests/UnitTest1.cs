using _01_KomodoCafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadMenuItems_ReturnMenuItems()
        {
            var menuRepo = new MenuRepo();

            var List = menuRepo.MenuList();

            CollectionAssert.AllItemsAreUnique(List);
        } 

        [TestMethod]
        public void AddingItemsToList()
        {
            //arrange
            var menuRepo = new MenuRepo();

            var addNewMenuItem = new Menu(1, "Iced Mocha Frappe", "Blended coffee and ice with chocolate flavor", "Coffee, Ice, Whipcrem, Chocolate Syrup, Milk", 5.99);

            int menuCountBefore = menuRepo._menu.Count;

            //act
            menuRepo.AddItemsToMenu(addNewMenuItem);

            int menuCountAfter = menuRepo._menu.Count;

            //assert
            Assert.AreEqual(menuCountBefore, menuCountAfter - 1);
        }


        [TestMethod]
        public void RemoveItemByNumber_Remove()
        {
            var menuRepo = new MenuRepo();

            var menuItemDelete = new Menu();

            menuRepo.AddItemsToMenu(menuItemDelete);

            menuRepo.RemoveMenuItems(menuItemDelete);

            CollectionAssert.DoesNotContain(menuRepo._menu, menuRepo);

        }
    }
}
