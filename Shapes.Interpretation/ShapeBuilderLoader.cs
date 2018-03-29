using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Shapes.Interpretation
{
    public class ShapeBuilderLoader : IShapeBuilderLoader
    {
        private readonly IShapeFactory factory_;

        public ShapeBuilderLoader(IShapeFactory factory)
        {
            factory_ = factory;
        }

        public IEnumerable<string> Load(Stream stream)
        {
            // TODO: think of another ways to load plugins
            var assembly = GetAssembly(stream);
            var builderPairs =
                from type in assembly.GetExportedTypes()
                let attribute = (ShapeBuilderAttribute)type.GetCustomAttribute(typeof(ShapeBuilderAttribute))
                where attribute != null
                select new {type, attribute};
            var registeredKeys = new List<string>();
            foreach (var builderPair in builderPairs)
            {
                try
                {
                    var shapeBuilder = (IShapeBuilder) Activator.CreateInstance(builderPair.type);
                    if (factory_.Register(builderPair.attribute.Key, shapeBuilder))
                    {
                        registeredKeys.Add(builderPair.attribute.Key);
                    }
                }
                catch
                {
                    // TODO: log. can be instantiation error, casting error
                }
            }

            return registeredKeys;
        }

        // TODO: extract
        private static Assembly GetAssembly(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var byteArray = memoryStream.ToArray();
                return Assembly.Load(byteArray);
            }
        }
    }
}
