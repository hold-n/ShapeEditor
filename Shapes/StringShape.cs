using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// A string shape.
    /// </summary>
    public class StringShape : IShape
    {
        private readonly Point point_;
        
        public StringShape(string text, Point point, BrushBillet brushBillet, FontBillet fontBillet)
        {
            Text = text;
            point_ = point;
            BrushBillet = brushBillet;
            FontBillet = fontBillet;
        }

        public BrushBillet BrushBillet { get; }

        public FontBillet FontBillet { get; }

        public Point Point => point_.Clone();

        public string Text { get; }

        public void Draw(Graphics graphics)
        {
            using (var brush = BrushBillet.CreateBrush())
            using (var font = FontBillet.CreateFont())
            {
                graphics.DrawString(Text, font, brush, point_);
            }
        }
    }
}
