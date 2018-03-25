using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Shapes
{
    public class AggregateShape : IShape
    {
        private readonly IShape[] shapes_;

        public AggregateShape(IEnumerable<IShape> shapes)
        {
            shapes_ = shapes.ToArray();
        }

        public void Draw(Graphics graphics)
        {
            foreach (IShape shape in shapes_)
            {
                shape.Draw(graphics);
            }
        }
    }
}
