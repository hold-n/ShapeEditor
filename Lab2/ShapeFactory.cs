using System;
using System.Collections.Generic;
using System.Linq;
using Shapes;

namespace Lab2
{
    public class ShapeFactory
    {
        private readonly Dictionary<string, IShapeBuilder> builders_ = new Dictionary<string, IShapeBuilder>();

        public IEnumerable<string> KnownNames => builders_.Keys;

        public IShape Create(string name, IEnumerable<string> parameters, DrawingContext context)
        {
            return builders_.TryGetValue(name.ToLowerInvariant(), out var builder)
                ? builder.Build(parameters.ToList(), context)
                : throw new ArgumentException($"Shape name {name} is not registered.");
        }

        public void Register(string name, IShapeBuilder shapeBuilder)
        {
            builders_[name.ToLowerInvariant()] = shapeBuilder;
        }
    }
}
