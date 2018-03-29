using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// An arc shape.
    /// </summary>
    public class ArcShape : IShape
    {
        private readonly Rectangle rect_;

        /// <summary>
        /// Creates an arc shape.
        /// </summary>
        /// <param name="rect">Bounding rectangle of the ellipse the arc belongs to.</param>
        /// <param name="startAngle"></param>
        /// <param name="sweepAngle"></param>
        /// <param name="penBillet"></param>
        public ArcShape(Rectangle rect, float startAngle, float sweepAngle, PenBillet penBillet)
        {
            rect_ = rect;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            PenBillet = penBillet;
        }

        public Rectangle EllipseRectangle => rect_.Clone();

        public float StartAngle { get; }

        public float SweepAngle { get; }

        public PenBillet PenBillet { get; }

        public void Draw(Graphics graphics)
        {
            using (var pen = PenBillet.CreatePen())
            {
                graphics.DrawArc(pen, rect_, StartAngle, SweepAngle);
            }
        }
    }
}
