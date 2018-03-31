using System.Collections.Generic;

namespace Shapes.Serialization
{
    // TODO: split interface
    public interface IShapeLoaderFactory
    {
        IEnumerable<string> Keys { get; }

        IShapeLoader Create();

        bool Register(ShapeLoaderInfo info);

        IEnumerable<ShapeLoaderInfo> SetActiveKeys(IEnumerable<string> keys);
    }
}
