using System.Text;

namespace MathParser
{
    public class GroupsExtractor
    {
        private readonly Calculator _calculator;

        public GroupsExtractor(Calculator calculator)
        {
            _calculator = calculator;
        }

        public string GetGroups(string mappedinputString)
        {
            int indexOfBracket = 0;
            StringBuilder expressionBuilder = new StringBuilder();
            for (int i = 0; i < mappedinputString.Length; i++)
            {
                if (mappedinputString[i] == ')')
                {
                    mappedinputString = ReplaceWithCalculatedExpression(mappedinputString, expressionBuilder);
                    break;
                }
                if (indexOfBracket > 0 && mappedinputString[i] != '(')
                {
                    expressionBuilder.Append(mappedinputString[i].ToString());
                }
                if (mappedinputString[i] == '(')
                {
                    indexOfBracket = i;
                }
            }
            return mappedinputString;
        }

        private string ReplaceWithCalculatedExpression(string mappedinputString, StringBuilder expression)
        {
            return mappedinputString.Replace("(" + expression + ")", _calculator.CalculateSingleExpression(expression.ToString()).ToString());
        }
    }
}