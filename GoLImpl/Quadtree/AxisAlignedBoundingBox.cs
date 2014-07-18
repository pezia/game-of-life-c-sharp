using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL.Quadtree
{
    public class AxisAlignedBoundingBox
    {
        public Point2D Center { get; set; }
        public Point2D HalfDimension { get; set; }

        public AxisAlignedBoundingBox(Point2D center, Point2D halfDimension)
        {
            this.Center = center;
            this.HalfDimension = halfDimension;
        }

        public bool contains(Point2D point)
        {
            return false;
        }

        public bool intersects(AxisAlignedBoundingBox other)
        {
            return false;
        }
    }
}
