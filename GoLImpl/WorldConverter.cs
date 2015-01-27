using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    public class WorldConverter
    {
        public World fromString(string input)
        {
            World world = new World();

            string[] lines = input.Split('\n');

            int maxLineLength = lines.Max(l => l.Length);

            int xOffset = (int)Math.Floor(maxLineLength / 2.0);
            int yOffset = (int)Math.Floor(lines.Length / 2.0);

            int x = 0;
            int y = 0;

            foreach (string line in lines)
            {
                x = 0;

                foreach (char character in line)
                {
                    if (character == 'x')
                    {
                        world.Add(new Cell(x - xOffset, y - yOffset));
                    }
                    x++;
                }
                y++;
            }

            return world;
        }
    }
}
