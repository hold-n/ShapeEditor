using System;
using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// Class that describes a brush and can create brushes by the description.
    /// </summary>
    public class BrushBillet
    {
        public BrushBillet(Color color, BrushType type)
        {
            Color = color;
            Type = type;
        }

        public Color Color { get; }

        public BrushType Type { get; }

        public Brush CreateBrush()
        {
            switch (Type)
            {
                case BrushType.Solid:
                    return new SolidBrush(Color);
                default:
                    throw new InvalidOperationException($"Invalid brush type: {Type}");
            }
        }
    }
}
