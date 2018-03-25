using System.Drawing;

namespace Shapes
{
    public class PenBillet
    {
        private readonly int? width_;
        private readonly Color color_;

        public PenBillet(Color color)
        {
            color_ = color;
        }

        public PenBillet(Color color, int width)
        {
            color_ = color;
            width_ = width;
        }

        public Pen CreatePen()
        {
            return width_.HasValue
                ? new Pen(color_, width_.Value)
                : new Pen(color_);
        }
    }
}
