using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shapes.Interpretation
{
    /// <summary>
    /// An interpreter creating shapes from their string representation.
    /// </summary>
    public class ShapeInterpreter : IShapeInterpreter
    {
        private static readonly Regex ShapeRegex = new Regex(@"^(?<name>\w+)\((?<coords>[^\)]*)\)$");

        private readonly IShapeFactory shapeFactory_;

        public ShapeInterpreter(IShapeFactory shapeFactory)
        {
            shapeFactory_ = shapeFactory;
        }

        public IEnumerable<IShape> Interpret(string text, DrawingContext context)
        {
            var lines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                .Where(line => !String.IsNullOrWhiteSpace(line));
            foreach (string line in lines)
            {
                // TODO: add support for control commands changing context
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
