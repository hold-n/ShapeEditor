using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Shapes.Interpretation;
using Shapes.Serialization;

namespace ShapeEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CreateForm());
        }

        private static Form CreateForm()
        {
            // TODO: DI container
            // TODO: init by attribute?
            var shapeFactory = new ShapeFactory();
            shapeFactory.Register("line", new LineShapeBuilder());
            shapeFactory.Register("arc", new ArcShapeBuilder());
            shapeFactory.Register("curve", new CurveShapeBuilder());
            shapeFactory.Register("rectangle", new RectangleShapeBuilder());
            shapeFactory.Register("ellipse", new EllipseShapeBuilder());
            shapeFactory.Register("string", new StringShapeBuilder());

            // NOTE: the same shapeFactory should be used in both => register as singleton
            var interpreter = new ShapeInterpreter(shapeFactory);
            var shapeBuilderLoader = new ShapeBuilderLoader(shapeFactory);
            var loader = new StreamShapeLoader();

            LoadPlugins(shapeBuilderLoader);
            return new MainForm(interpreter, loader);
        }

        private static void LoadPlugins(IShapeBuilderLoader loader)
        {
            var fileNames = (ConfigurationManager.AppSettings["pluginDlls"] ?? "")
                .Split(new [] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string fileName in fileNames)
            {
                try
                {
                    using (var stream = File.Open(fileName, FileMode.Open))
                    {
                        loader.Load(stream);
                    }
                }
                catch (Exception e)
                {
                    // TODO: log
                }
            }
        }
    }
}
