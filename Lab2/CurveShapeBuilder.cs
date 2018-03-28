using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Shapes;

namespace Lab2
{
    public class CurveShapeBuilder : IShapeBuilder
    {
        public IShape Build(IList<string> parameters, DrawingContext context)
        {
            if (parameters.Count % 2 != 0)
            {
                throw new ArgumentException($"The number of parameters must be even.");
            }
            var intParameters = parameters
                .Select(int.Parse)
                .ToList();
            var points = intParameters
                .Zip(intParameters.Skip(1), (a, b) => new Point(a, b))
                .Where((_, index) => index % 2 == 0)
                .ToList();
            return new CurveShape(points, context.CreatePenBillet());
        }
    }
}