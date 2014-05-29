using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class Cell : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            Cell cell = other as Cell;
            return cell != null && cell.X == X && cell.Y == Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        } 

        public List<ICell> getNeighbours()
        {
            List<ICell> neighbours = new List<ICell>();
            for (int x = X - 1; x <= X + 1; x++)
            {
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    if (x == X && y == Y)
                    {
                        continue;
                    }
                    neighbours.Add(new Cell(x, y));
                }
            }
            return neighbours;
        }
    }
}
