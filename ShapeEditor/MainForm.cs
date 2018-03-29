using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Shapes;
using Shapes.Interpretation;
using Shapes.Serialization;

namespace ShapeEditor
{
    public partial class MainForm : Form
    {
        private readonly IShapeInterpreter interpreter_;
        private readonly IStreamShapeLoader loader_;
        private readonly List<IShape> shapes_ = new List<IShape>();

        public MainForm(IShapeInterpreter interpreter, IStreamShapeLoader loader)
        {
            InitializeComponent();

            interpreter_ = interpreter;
            loader_ = loader;
        }

        #region Logic

        private ICollection<IShape> InterpretShapes(string text)
        {
            try
            {
                // TODO?: persist context
                var context = new DrawingContext();
                // TODO: display available keys
                return interpreter_.Interpret(text, context).ToList();
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                return null;
            }
        }

        private ICollection<IShape> LoadShapesFromStream(Stream stream)
        {
            try
            {
                return loader_.Load(stream).ToList();
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                return null;
            }
        }

        private void Redraw(ICollection<IShape> shapes)
        {
            if (shapes != null)
            {
                shapes_.Clear();
                shapes_.AddRange(shapes);
                shapePictureBox.Invalidate();
                errorLabel.Text = "";
            }
        }

        private void SaveShapesToStream(Stream stream)
        {
            try
            {
                loader_.Save(stream, shapes_);
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        #endregion

        private void shapePictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (IShape shape in shapes_)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void interpretButton_Click(object sender, EventArgs e)
        {
            var shapes = InterpretShapes(interpretTextArea.Text);
            Redraw(shapes);
        }

        private void interpretTextArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                var shapes = InterpretShapes(interpretTextArea.Text);
                Redraw(shapes);
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using (Stream stream = openFileDialog1.OpenFile())
                {
                    var shapes = LoadShapesFromStream(stream);
                    Redraw(shapes);
                }
            }
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using (Stream stream = saveFileDialog1.OpenFile())
                {
                    SaveShapesToStream(stream);
                }
            }
        }
    }
}
