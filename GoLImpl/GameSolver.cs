using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class GameSolver
    {
        public World evolve(World world)
        {
            World newWorld = new World();

            var births = world.getPossibleBirths().Where((possibleBirth) => world.getNeighbourCount(possibleBirth) == 3);
            var cells = world.Where((worldCell) =>
            {
                int neighbourCount = world.getNeighbourCount(worldCell);
                return neighbourCount == 2 || neighbourCount == 3;
            });

            cells.Union(births).ToList().ForEach((cell) => newWorld.Add(cell));

            return newWorld;
        }
    }
}
