using System.Drawing;

namespace Shapes
{
    public class ArcShape : IShape
    {
        private readonly Rectangle rect_;
        private readonly float startAngle_;
        private readonly float sweepAngle_;
        private readonly PenBillet penBillet_;

        public ArcShape(Rectangle rect, float startAngle, float sweepAngle, PenBillet penBillet)
        {
            rect_ = rect;
            startAngle_ = startAngle;
            sweepAngle_ = sweepAngle;
            penBillet_ = penBillet;
        }

        public void Draw(Graphics graphics)
        {
            using (var pen = penBillet_.CreatePen())
            {
                graphics.DrawArc(pen, rect_, startAngle_, sweepAngle_);
            }
        }
    }
}
