using System.Collections.Generic;
using System.IO;

namespace Shapes.Serialization
{
    public interface IStreamShapeLoader
    {
        IEnumerable<IShape> Load(Stream stream);

        void Save(Stream stream, IEnumerable<IShape> shapes);
    }
}
