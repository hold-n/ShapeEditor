using System.Collections.Generic;
using System.IO;

namespace Shapes.Interpretation
{
    public interface IShapeBuilderLoader
    {
        IEnumerable<string> Load(Stream dllStream);
    }
}
