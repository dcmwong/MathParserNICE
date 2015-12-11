using System.Collections.Generic;
using System.Linq;

namespace MathParser
{
    public class Mapper
    {
        public string MapInputString(string inputString)
        {
            Dictionary<char, char> mappings = new Dictionary<char, char>
            {
                {
                    'a', '+'
                },
                {
                    'b', '-'
                },
                {
                    'c', '*'
                },
                {
                    'd', '/'
                },
                {
                    'e', '('
                },
                {
                    'f', ')'
                },
            };

            return mappings.Aggregate(inputString, (current, mapping) => current.Replace(mapping.Key, mapping.Value));
        }
    }
}