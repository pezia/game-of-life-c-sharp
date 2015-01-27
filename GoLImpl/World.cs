using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class World : HashSet<ICell>
    {
        public bool isAlive(ICell cell)
        {
            return this.Contains(cell);
        }

        public int getNeighbourCount(ICell cell)
        {
            return cell.getNeighbours().Count((neighbour) => isAlive(neighbour));
        }

        public List<ICell> getPossibleBirths()
        {
            List<ICell> possibleCells = new List<ICell>();
            this.ToList().ForEach((cell) =>
            {
                possibleCells.AddRange(
                    cell.getNeighbours().Where((neighbour) => !isAlive(neighbour))
                    );
            });
            return possibleCells.Distinct().ToList();
        }
    }
}
