using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// An ellipse shape.
    /// </summary>
    public class EllipseShape : IShape
    {
        private readonly Point upperLeftCorner_;

        public EllipseShape(Point upperLeftCorner, Point lowerRightCorner, PenBillet billet)
        {
            upperLeftCorner_ = upperLeftCorner;
            Billet = billet;
            Width = lowerRightCorner.X - upperLeftCorner.X;
            Height = lowerRightCorner.Y - upperLeftCorner.Y;
        }

        public PenBillet Billet { get; }

        public int Height { get; }

        public Point UpperLeftCorner => upperLeftCorner_.Clone();

        public int Width { get; }

        public void Draw(Graphics graphics)
        {
            using (var pen = Billet.CreatePen())
            {
                graphics.DrawEllipse(pen, upperLeftCorner_.X, upperLeftCorner_.Y, Width, Height);
            }
        }
    }
}
