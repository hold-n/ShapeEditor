namespace Shapes.Serialization
{
    public interface IShapeLoaderBuilder
    {
        IShapeLoader Decorate(IShapeLoader shapeLoader);
    }
}
