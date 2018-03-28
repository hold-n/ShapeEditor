using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Shapes;

namespace Lab2
{
    public partial class MainForm : Form
    {
        private List<IShape> shapes_ = new List<IShape>();
        private readonly ShapeInterpreter interpreter_;

        public MainForm(ShapeInterpreter interpreter)
        {
            InitializeComponent();

            var shapeFactory = new ShapeFactory();
            shapeFactory.Register("line", new LineShapeBuilder());
            shapeFactory.Register("arc", new ArcShapeBuilder());
            shapeFactory.Register("curve", new CurveShapeBuilder());
            shapeFactory.Register("rectangle", new RectangleShapeBuilder());
            shapeFactory.Register("ellipse", new EllipseShapeBuilder());
            shapeFactory.Register("string", new StringShapeBuilder());

            interpreter_ = new ShapeInterpreter(shapeFactory);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (IShape shape in shapes_)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new DrawingContext();
                shapes_ = interpreter_.Interpret(textBox1.Text, context).ToList();
                pictureBox1.Invalidate();
                label1.Text = "";
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }
    }
}
