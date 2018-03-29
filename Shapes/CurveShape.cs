using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Shapes
{
    /// <summary>
    /// A curvd line shape.
    /// </summary>
    public class CurveShape : IShape
    {
        private readonly Point[] points_;

        public CurveShape(IEnumerable<Point> points, PenBillet billet)
        {
            PenBillet = billet;
            points_ = points.ToArray();
        }

        public PenBillet PenBillet { get; }

        public IEnumerable<Point> Points => points_.Select(point => point.Clone());

        public void Draw(Graphics graphics)
        {
            using (var pen = PenBillet.CreatePen())
            {
                graphics.DrawCurve(pen, points_);
            }
        }
    }
}
