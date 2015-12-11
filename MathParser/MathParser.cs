using System;
using System.Collections.Generic;

namespace MathParser
{
    public class MathParser
    {
        private readonly Mapper _mapper;
        private readonly GroupsExtractor _groupsExtractor;
        private readonly Calculator _calculator;

        public MathParser(Mapper mapper, GroupsExtractor groupsExtractor, Calculator calculator)
        {
            _mapper = mapper;
            _groupsExtractor = groupsExtractor;
            _calculator = calculator;
        }

        

        public int Calculate(string inputString)
        {
            var mappedinputString = _mapper.MapInputString(inputString);

            string expressions = _groupsExtractor.GetGroups(mappedinputString);
            while (expressions.Contains("("))
                expressions = _groupsExtractor.GetGroups(expressions);
            return _calculator.CalculateSingleExpression(expressions);
        }
    }
}
