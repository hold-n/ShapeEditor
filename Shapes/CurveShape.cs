using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Shapes
{
    public class CurveShape : IShape
    {
        private readonly PenBillet billet_;
        private readonly Point[] points_;

        public CurveShape(IEnumerable<Point> points, PenBillet billet)
        {
            billet_ = billet;
            points_ = points.ToArray();
        }

        public void Draw(Graphics graphics)
        {
            using (var pen = billet_.CreatePen())
            {
                graphics.DrawCurve(pen, points_);
            }
        }
    }
}
