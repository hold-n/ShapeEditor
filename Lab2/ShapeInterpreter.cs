using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shapes;

namespace Lab2
{
    public class ShapeInterpreter
    {
        private static readonly Regex ShapeRegex = new Regex(@"^(?<name>\w+)\((?<coords>[^\)]*)\)$");

        private readonly ShapeFactory shapeFactory_;

        public ShapeInterpreter(ShapeFactory shapeFactory)
        {
            shapeFactory_ = shapeFactory;
        }

        public IEnumerable<IShape> Interpret(string text, DrawingContext context)
        {
            foreach (string line in text.Split(new [] { Environment.NewLine }, StringSplitOptions.None))
            {
                yield return ParseShape(line, context);
            }
        }

        private IShape ParseShape(string line, DrawingContext context)
        {
            var match = ShapeRegex.Match(line);
            if (!match.Success)
            {
                throw new FormatException($"Invalid shape declaration: {line}");
            }
            var shapeName = match.Groups["name"].Value;
            var parameters = match.Groups["coords"].Value
                .Split(',')
                .Select(item => item.Trim());
            return shapeFactory_.Create(shapeName, parameters, context);
        }
    }
}
