using System;
using System.Collections.Generic;
using _01_KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KomodoClaimsTests
{
    [TestClass]
    public class RepoTesting
    {
        KomodoClaimsRepo _repo = new KomodoClaimsRepo();
        [TestMethod]
        public void WasAdded_ShouldReturnTrue()
        {
            Claim testClaim = new Claim();
            bool testHold = _repo.AddContentToDirectory(testClaim);

            Assert.IsTrue(testHold);

        }

        [TestMethod]
        public void RemoveFirstItem_ShouldReturnTrue()
        {
            Claim testClaim = new Claim(2, "something", "cool", "$500", "something", "cool", false);
            bool testHold = _repo.AddContentToDirectory(testClaim);
            //Console.WriteLine(tes)
            Claim secondClaim = new Claim(6, "something else", "rad", "2304", "something", "doesnt matter", true);
            bool testTwo = _repo.AddContentToDirectory(secondClaim);

            bool removedSuccessfully = _repo.RemoveFirstClaim();
            Assert.IsTrue(removedSuccessfully);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnListOfClaims()
        {
            Claim content = new Claim();
            KomodoClaimsRepo repo = new KomodoClaimsRepo();

            repo.AddContentToDirectory(content);
            List<Claim> fullRepo = repo.GetAllClaims();

            bool directoryHasContents = fullRepo.Contains(content);

            Assert.IsTrue(directoryHasContents);
        }

    }
}
