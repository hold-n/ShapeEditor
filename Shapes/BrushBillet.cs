using System;
using System.Drawing;

namespace Shapes
{
    public class BrushBillet
    {
        private readonly Color color_;
        private readonly BrushType type_;

        public BrushBillet(Color color, BrushType type)
        {
            color_ = color;
            type_ = type;
        }

        public Brush CreateBrush()
        {
            switch (type_)
            {
                case BrushType.Solid:
                    return new SolidBrush(color_);
                default:
                    throw new InvalidOperationException($"Invalid brush type: {type_}");
            }
        }
    }
}