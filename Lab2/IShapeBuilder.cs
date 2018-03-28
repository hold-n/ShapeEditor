using System.Collections.Generic;
using Shapes;

namespace Lab2
{
    public interface IShapeBuilder
    {
        IShape Build(IList<string> parameters, DrawingContext context);
    }
}
