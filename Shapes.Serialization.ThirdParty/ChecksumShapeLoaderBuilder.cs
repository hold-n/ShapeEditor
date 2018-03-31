namespace Shapes.Serialization.ThirdParty
{
    [ShapeLoaderBuilder("Check integrity")]
    public class ChecksumShapeLoaderBuilder : IShapeLoaderBuilder
    {
        public IShapeLoader Decorate(IShapeLoader shapeLoader)
        {
            return new ChecksumShapeLoaderDecorator(shapeLoader, new Md5Hash());
        }
    }
}
