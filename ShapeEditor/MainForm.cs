using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Shapes;
using Shapes.Interpretation;

namespace ShapeEditor
{
    public partial class MainForm : Form
    {
        private List<IShape> shapes_ = new List<IShape>();
        private readonly ShapeInterpreter interpreter_;

        public MainForm(ShapeInterpreter interpreter)
        {
            InitializeComponent();

            interpreter_ = interpreter;
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
