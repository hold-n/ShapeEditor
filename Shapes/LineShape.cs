using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// A line shape.
    /// </summary>
    public class LineShape : IShape
    {
        private readonly Point start_;
        private readonly Point end_;

        public LineShape(Point start, Point end, PenBillet billet)
        {
            start_ = start;
            end_ = end;
            PenBillet = billet;
        }

        public Point End => end_.Clone();

        public PenBillet PenBillet { get; }

        public Point Start => start_.Clone();

        public void Draw(Graphics graphics)
        {
            using (var pen = PenBillet.CreatePen())
            {
                graphics.DrawLine(pen, start_, end_);
            }
        }
    }
}
