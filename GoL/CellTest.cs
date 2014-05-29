using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GoL
{
    [TestClass]
    public class CellTest
    {

        [TestMethod]
        public void TestCellEquals()
        {
            Assert.AreEqual(new Cell(0, 0), new Cell(0, 0));
        }

        [TestMethod]
        public void TestCellGetNeighbours()
        {
            Assert.AreEqual(8, new Cell(0, 0).getNeighbours().Count);
            Assert.IsTrue(new Cell(0, 0).getNeighbours().Contains(new Cell(-1, -1)));
        }
    }
}
