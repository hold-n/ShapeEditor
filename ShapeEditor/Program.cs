using System;
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
            // TODO: DI container
            // TODO: init by attribute?
            var shapeFactory = new ShapeFactory();
            shapeFactory.Register("line", new LineShapeBuilder());
            shapeFactory.Register("arc", new ArcShapeBuilder());
            shapeFactory.Register("curve", new CurveShapeBuilder());
            shapeFactory.Register("rectangle", new RectangleShapeBuilder());
            shapeFactory.Register("ellipse", new EllipseShapeBuilder());
            shapeFactory.Register("string", new StringShapeBuilder());

            // NOTE: shapeFactory should be registered as singleton
            var interpreter = new ShapeInterpreter(shapeFactory);
            var shapeBuilderLoader = new ShapeBuilderLoader(shapeFactory);
            var loader = new StreamShapeLoader();

            var mainForm = new MainForm(interpreter, loader);

            var app = new ShapeEditorApp(shapeBuilderLoader, mainForm);
            app.Run();
        }
    }
}
