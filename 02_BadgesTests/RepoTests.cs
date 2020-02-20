using System;
using System.Collections.Generic;
using _02_BadgesClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_BadgesTests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void AddBadgeToRepo_ShouldReturnTrue()
        {
            BadgeRepo _badges = new BadgeRepo();
            Badge firstBadge = new Badge(1, new List<string> { "A5", "B7", "C9" });

            bool actual = _badges.AddBadgeToRepo(firstBadge);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void UpdateBadgeByID_ShouldReturnTrue()
        {
            BadgeRepo _badges = new BadgeRepo();
            Badge firstBadge = new Badge(1, new List<string> { "A5", "B7", "C9" });
            _ = _badges.AddBadgeToRepo(firstBadge);
            // c# discard
            // it essentially is a way for us to still catch the value but we will never use it so it get's thrown away


            bool updated = _badges.UpdateBadgeByID(1, new List<string> { "A2", "B6", "C5" });
            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void MyTestMethod()
        {

            Badge content = new Badge(5, new List<string> { "A5", "B7", "C9"});
            BadgeRepo repo = new BadgeRepo();

            repo.AddBadgeToRepo(content);
            Dictionary<int, List<string>> fullRepo = repo.GetAllBadges();

            bool directoryHasContents = fullRepo.ContainsKey(content.BadgeID);

            Assert.IsTrue(directoryHasContents);
        }
    }
}
