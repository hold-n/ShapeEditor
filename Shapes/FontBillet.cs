using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// A class describing a font and capable of creating fonts by the description.
    /// </summary>
    public class FontBillet
    {
        public FontBillet(string familyName, float emSize)
        {
            FamilyName = familyName;
            EmSize = emSize;
        }

        public float EmSize { get; }

        public string FamilyName { get; }

        /// <summary>
        /// Creates a font according to the stored settings.
        /// </summary>
        /// <returns></returns>
        public Font CreateFont()
        {
            return new Font(FamilyName, EmSize);
        }
    }
}
