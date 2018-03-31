namespace Shapes.Serialization.ThirdParty
{
    [ShapeLoaderBuilder("Archive")]
    public class ZipShapeLoaderBuilder : IShapeLoaderBuilder
    {
        public IShapeLoader Decorate(IShapeLoader shapeLoader)
        {
            return new ZipShapeLoaderDecorator(shapeLoader);
        }
    }
}
