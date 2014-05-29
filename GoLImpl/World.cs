using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class World<T> : HashSet<T> where T : ICell
    {
        public bool isAlive(T cell)
        {
            return this.Contains(cell);
        }

        public int getNeighbourCount(T cell)
        {
            return cell.getNeighbours().Where(c => this.Contains((T)c)).Count();
        }

    }
}
