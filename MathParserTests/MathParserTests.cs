using MathParser;
using NUnit.Framework;

namespace MathParserTests
{
    [TestFixture]
    public class MathParserTests
    {
        [TestCase("3a2c4", 20)]
        [TestCase("32a2d2", 17)]
        [TestCase("500a10b66c32", 14208)]
        [TestCase("3ae4c66fb32", 235)]
        [TestCase("3c4d2aee2a4c41fc4f", 990)]
        public void ShouldParseAndCalculateTotal(string inputString, int expectedResult)
        {
            var mathParserMapper = new Mapper();
            var calculator = new Calculator();
            var groupsExtractor = new GroupsExtractor(calculator);
            

            var mathParser = new MathParser.MathParser(mathParserMapper, groupsExtractor, calculator);
            int calculatedResult = mathParser.Calculate(inputString);

            Assert.That(calculatedResult, Is.EqualTo(expectedResult)); 
        }
    }
}
