using MathParser;
using NUnit.Framework;

namespace MathParserTests
{
    [TestFixture]
    public class MapInputStringTests
    {

        [TestCase("3a2c4", "3+2*4")]
        [TestCase("3c4d2aee2a4c41fc4f", "3*4/2+((2+4*41)*4)")]
        public void ShouldMapInput_WithOperators(string inputString, string expectedString)
        {
            var mapper = new Mapper();
            string mappedinputString = mapper.MapInputString(inputString);
            Assert.That(mappedinputString, Is.EqualTo(expectedString));
        }

    }
}
