using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class GameSolver<T> : Object where T : ICell
    {
        public World<T> evolve(World<T> world)
        {
            World<T> newWorld = new World<T>();

            List<ICell> possibleBirths = new List<ICell>();

            foreach (T cell in world)
            {
                int neighbourCount = world.getNeighbourCount(cell);

                if (neighbourCount == 2 || neighbourCount == 3)
                {
                    newWorld.Add(cell);
                }

                possibleBirths.AddRange(cell.getNeighbours());
            }

            foreach (ICell possibleBirthCell in possibleBirths)
            {
                if (!world.isAlive((T)possibleBirthCell) && world.getNeighbourCount((T)possibleBirthCell) == 3)
                {
                    newWorld.Add((T)possibleBirthCell);
                }
            }

            return newWorld;
        }
    }
}
