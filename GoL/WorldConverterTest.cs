using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoL
{
    [TestClass]
    public class WorldConverterTest
    {
        WorldConverter worldConverter;

        [TestInitialize]
        public void setUp()
        {
            worldConverter = new WorldConverter();
        }

        [TestMethod]
        public void TestFromStringWithEmptyString()
        {
            string input = "";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(0, world.Count);
        }

        [TestMethod]
        public void TestFromStringWithOneCell()
        {
            string input = "x";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(1, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
        }


        [TestMethod]
        public void TestFromStringWithTwoCellsInOneLine()
        {
            string input = "xx";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(2, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(-1, 0)));
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestFromStringWithTwoCellsInTwoLines()
        {
            string input = "x\nx";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(2, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(0, -1)));
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestFromStringWithTwoCellsInTwoLinesDiagonal()
        {
            string input = "x\n x";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(2, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(-1, -1)));
            Assert.IsTrue(world.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestFromStringWithGlider()
        {
            string input = " x\n  x\nxxx";

            World world = worldConverter.fromString(input);

            Assert.AreEqual(5, world.Count);
            Assert.IsTrue(world.isAlive(new Cell(0, -1)));
            Assert.IsTrue(world.isAlive(new Cell(1, 0)));
            Assert.IsTrue(world.isAlive(new Cell(-1, 1)));
            Assert.IsTrue(world.isAlive(new Cell(0, 1)));
            Assert.IsTrue(world.isAlive(new Cell(1, 1)));
        }
    }
}
