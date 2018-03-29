using System.Drawing;

namespace Shapes
{
    public class RectangleShape : IShape
    {
        private readonly Point upperLeftCorner_;
        
        public RectangleShape(Point upperLeftCorner, Point lowerRightCorner, PenBillet billet)
        {
            upperLeftCorner_ = upperLeftCorner;
            PenBillet = billet;
            Width = lowerRightCorner.X - upperLeftCorner.X;
            Height = lowerRightCorner.Y - upperLeftCorner.Y;
        }

        public int Height { get; }

        public PenBillet PenBillet { get; }

        public Point UpperLeftCorner => upperLeftCorner_.Clone();

        public int Width { get; }

        public void Draw(Graphics graphics)
        {
            using (var pen = PenBillet.CreatePen())
            {
                graphics.DrawRectangle(pen, upperLeftCorner_.X, upperLeftCorner_.Y, Width, Height);
            }
        }   
    }
}
