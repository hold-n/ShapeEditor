using System.Collections.Generic;
using System.Linq;

namespace Shapes.Serialization
{
    public class ShapeLoaderFactory : IShapeLoaderFactory
    {
        private readonly IShapeLoader coreLoader_;
        private readonly Dictionary<string, ShapeLoaderInfo> shapeLoaders_ = new Dictionary<string, ShapeLoaderInfo>();
        private readonly List<ShapeLoaderInfo> activeLoaders_ = new List<ShapeLoaderInfo>();

        public ShapeLoaderFactory(IShapeLoader coreLoader)
        {
            coreLoader_ = coreLoader;
        }

        public IEnumerable<string> Keys => shapeLoaders_.Keys;

        public IShapeLoader Create()
        {
            var loader = coreLoader_;
            foreach (ShapeLoaderInfo info in activeLoaders_)
            {
                loader = info.Builder.Decorate(loader);
            }
            return loader;
        }

        public bool Register(ShapeLoaderInfo info)
        {
            if (!shapeLoaders_.ContainsKey(info.Key))
            {
                shapeLoaders_[info.Key] = info;
                activeLoaders_.Add(info);
                return true;
            }
            return false;
        }

        public IEnumerable<ShapeLoaderInfo> SetActiveKeys(IEnumerable<string> keys)
        {
            var loaders = keys.Select(key =>
            {
                shapeLoaders_.TryGetValue(key, out var info);
                return info;
            }).Where(info => info != null);
            activeLoaders_.Clear();
            activeLoaders_.AddRange(loaders);
            return activeLoaders_;
        }
    }
}
