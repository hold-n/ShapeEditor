using System.Drawing;

namespace Shapes
{
    public class FontBillet
    {
        private readonly string familyName_;
        private readonly float emSize_;

        public FontBillet(string familyName, float emSize)
        {
            familyName_ = familyName;
            emSize_ = emSize;
        }

        public Font CreateFont()
        {
            return new Font(familyName_, emSize_);
        }
    }
}
