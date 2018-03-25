using System.Drawing;

namespace Shapes
{
    public class LineShape : IShape
    {
        private readonly Point start_;
        private readonly Point end_;
        private readonly PenBillet billet_;

        public LineShape(Point start, Point end, PenBillet billet)
        {
            start_ = start;
            end_ = end;
            billet_ = billet;
        }

        public void Draw(Graphics graphics)
        {
            using (var pen = billet_.CreatePen())
            {
                graphics.DrawLine(pen, start_, end_);
            }
        }
    }
}
