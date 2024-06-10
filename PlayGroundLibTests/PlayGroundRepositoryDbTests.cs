using PlayGroundLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlayGroundLib.Tests
{
    [TestClass]
    public class PlayGroundRepositoryDbTests
    {
        private DbContextOptions<PlayGroundDbContext> DbContextOptions; //her opretter vi en variabel af typen DbContextOptions<PlayGroundDbContext> som vi kan bruge i vores tests
        private PlayGroundRepositoryDb _playGroundRepositoryDb; // her opretter vi en variabel af typen PlayGroundRepositoryDb som vi kan bruge i vores tests
        public PlayGroundRepositoryDbTests()
        {
            DbContextOptions = new DbContextOptionsBuilder<PlayGroundDbContext>().UseInMemoryDatabase(databaseName: "PlayGroundses").Options; //her opretter vi en variabel af typen DbContextOptionsBuilder<PlayGroundDbContext> som vi kan bruge i vores tests
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var inMemoryDbContext = new PlayGroundDbContext(DbContextOptions);
            inMemoryDbContext.PlayGrounds.AddRange(
                    new PlayGround { Name = "tgdag", MaxChildren = 2, MinAge = 5 },
                    new PlayGround { Name = "dhggdhdgh", MaxChildren = 60, MinAge = 6 },
                    new PlayGround { Name = "dhghgfh", MaxChildren = 70, MinAge = 7 }
                );
            inMemoryDbContext.SaveChanges();
            _playGroundRepositoryDb = new PlayGroundRepositoryDb(inMemoryDbContext);
            
        }


        [TestMethod]
        public void GetAllPlayGroundsTest()
        {
            var playGrounds = _playGroundRepositoryDb.GetAllPlayGrounds();
            Assert.AreEqual(3, playGrounds.Count);
        }

        [TestMethod()]
        public void GetPlayGroundByIdTest()
        {
            var playGround = _playGroundRepositoryDb.GetPlayGroundById(1);
            Assert.AreEqual("tgdag", playGround.Name);
        }

        [TestMethod()]
        public void AddPlayGroundTest()
        {
            var playGround = new PlayGround { Name = "tgdag", MaxChildren = 2, MinAge = 5 };
            var result = _playGroundRepositoryDb.AddPlayGround(playGround);
            Assert.AreEqual(4, result.Id);
            
        }

        [TestMethod()]
        public void UpdatePlayGroundTest()
        {
            var playGround = new PlayGround { Name = "UpdateName", MaxChildren = 2, MinAge = 5 };
            var result = _playGroundRepositoryDb.UpdatePlayGround(playGround, 1);
            Assert.AreEqual("UpdateName", result.Name);
            Assert.AreEqual(2, result.MaxChildren);
            Assert.AreEqual(5, result.MinAge);
        }
    }
}