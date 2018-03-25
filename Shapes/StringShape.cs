using System.Drawing;

namespace Shapes
{
    public class StringShape : IShape
    {
        private readonly string text_;
        private readonly Point point_;
        private readonly BrushBillet brushBillet_;
        private readonly FontBillet fontBillet_;

        public StringShape(string text, Point point, BrushBillet brushBillet, FontBillet fontBillet)
        {
            text_ = text;
            point_ = point;
            brushBillet_ = brushBillet;
            fontBillet_ = fontBillet;
        }

        public void Draw(Graphics graphics)
        {
            using (var brush = brushBillet_.CreateBrush())
            using (var font = fontBillet_.CreateFont())
            {
                graphics.DrawString(text_, font, brush, point_);
            }
        }
    }
}
