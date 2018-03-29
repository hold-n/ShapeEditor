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
        private readonly ShapeInterpreter interpreter_;

        private readonly List<IShape> shapes_ = new List<IShape>();

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
            Redraw();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                Redraw();
                e.SuppressKeyPress = true;
            }
        }

        private void LoadShapes()
        {
            var context = new DrawingContext();
            shapes_.Clear();
            shapes_.AddRange(interpreter_.Interpret(textBox1.Text, context).ToList());
        }

        private void Redraw()
        {
            try
            {
                LoadShapes();
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
