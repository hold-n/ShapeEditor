namespace Shapes.Serialization
{
    public class ShapeLoaderInfo
    {
        public ShapeLoaderInfo(string key, string title, IShapeLoaderBuilder builder)
        {
            Key = key;
            Title = title;
            Builder = builder;
        }

        public string Key { get; }

        public string Title { get; }

        public IShapeLoaderBuilder Builder { get; }
    }
}
