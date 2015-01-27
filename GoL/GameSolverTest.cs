using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GoL
{
    [TestClass]
    public class GameSolverTest
    {
        World world;
        GameSolver solver;

        [TestInitialize]
        public void setUp()
        {
            world = new World();
            solver = new GameSolver();
        }

        [TestMethod]
        public void TestGameSolverHasEvolveMethod()
        {
            Assert.IsInstanceOfType(solver.evolve(world), typeof(World));
        }

        [TestMethod]
        public void TestEmptyWorldEvolvesToEmptyWorld()
        {
            Assert.AreEqual(0, solver.evolve(world).Count);
        }

        [TestMethod]
        public void TestSingleCellDies()
        {
            world.Add(new Cell(0, 0));
            var newWorld = solver.evolve(world);
            Assert.IsFalse(newWorld.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestCellWithOneNeighbourDies()
        {
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));

            var newWorld = solver.evolve(world);

            Assert.IsFalse(newWorld.isAlive(new Cell(0, 0)));
            Assert.IsFalse(newWorld.isAlive(new Cell(0, 1)));
        }

        [TestMethod]
        public void TestCellWithTwoNeighbourLivesOn()
        {
            world.Add(new Cell(0, -1));
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));

            var newWorld = solver.evolve(world);

            Assert.IsTrue(newWorld.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestCellWithThreeNeighbourLivesOn()
        {
            world.Add(new Cell(0, -1));
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));
            world.Add(new Cell(1, 0));

            var newWorld = solver.evolve(world);

            Assert.IsTrue(newWorld.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestCellWithFourNeighbourDies()
        {
            world.Add(new Cell(0, -1));
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));
            world.Add(new Cell(1, 0));
            world.Add(new Cell(-1, 0));

            var newWorld = solver.evolve(world);

            Assert.IsFalse(newWorld.isAlive(new Cell(0, 0)));
        }

        [TestMethod]
        public void TestDeadCellWithThreeNeighbourBirths()
        {
            world.Add(new Cell(0, -1));
            world.Add(new Cell(0, 0));
            world.Add(new Cell(0, 1));

            var newWorld = solver.evolve(world);

            Assert.IsTrue(newWorld.isAlive(new Cell(1, 0)));
            Assert.IsTrue(newWorld.isAlive(new Cell(-1, 0)));
        }
    }
}
