using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoL
{
    [TestClass]
    public class WorldTest
    {
        World world;

        [TestInitialize]
        public void setUp()
        {
            world = new World();
        }

        [TestMethod]
        public void TestContainsUniqueCells()
        {
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 0));

            world.Add(new Cell(1, 0));
            world.Add(new Cell(0, 1));

            Assert.AreEqual(3, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestIsAlive()
        {
            world.Add(new Cell(0, 0));
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
            Assert.IsFalse(world.isAlive(new Cell(1, 1)));
        }

        [TestMethod]
        public void TestNeighbourCountZero()
        {
            world.Add(new Cell(0, 0));
            Assert.AreEqual(0, world.getNeighbourCount(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestNeighbourCountOne()
        {
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));
            world.Add(new Cell(10, 10));

            Assert.AreEqual(1, world.getNeighbourCount(new Cell(0, 0)));
        }
        [TestMethod]
        public void TestNeighbourCountTwo()
        {
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));
            world.Add(new Cell(0, 2));

            Assert.AreEqual(2, world.getNeighbourCount(new Cell(0, 1)));
        }
    }
}
