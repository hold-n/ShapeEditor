using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// A class describing a pen and capable of creating pens by the description.
    /// </summary>
    public class PenBillet
    {
        public PenBillet(Color color)
        {
            Color = color;
        }

        public PenBillet(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public Color Color { get; }

        public int? Width { get; }

        public Pen CreatePen()
        {
            return Width.HasValue
                ? new Pen(Color, Width.Value)
                : new Pen(Color);
        }
    }
}
