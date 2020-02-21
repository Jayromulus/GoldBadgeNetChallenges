using System;
using System.Collections.Generic;
using _01_CafeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void AddMenuItemToRepository_ShouldReturnTrue()
        {
            CafeRepo _repo = new CafeRepo();
            MenuItem myItem = new MenuItem();

            bool wasAdded = _repo.AddMenuItemToRepository(myItem);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveMenuItemFromRepository_ShouldReturnTrue()
        {
            CafeRepo _repo = new CafeRepo();
            MenuItem myItem = new MenuItem();
            myItem.MealNumber = 5;
            _repo.AddMenuItemToRepository(myItem);

            bool wasRemoved = _repo.RemoveMenuItemFromRepository(myItem);

            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnListOfMenuItems()
        {
            MenuItem content = new MenuItem();
            CafeRepo repo = new CafeRepo();

            repo.AddMenuItemToRepository(content);
            List<MenuItem> fullRepo = repo.GetAllMenuItems();

            bool directoryHasContents = fullRepo.Contains(content);

            Assert.IsTrue(directoryHasContents);
        }
    }
}
