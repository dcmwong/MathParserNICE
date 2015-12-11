using System;
using System.Collections.Generic;

namespace MathParser
{
    public class Calculator
    {
        public int CalculateSingleExpression(string input)
        {
            Stack<char> stackOfOperators = new Stack<char>();
            int getResult = -1;
            bool lastCharacterWasANumber = true;
            bool concatenateToSecondNumber = false;
            int second = -1;

            for (int index = 0; index < input.Length; index++)
            {
                var currentCharacterIsANumber = Char.IsNumber(input[index]);

                if (lastCharacterWasANumber && currentCharacterIsANumber)
                {
                    getResult = GetFirstNumber(input, getResult, index);
                }
                else if (currentCharacterIsANumber && getResult < 0)
                {
                    getResult = GetFirstNumber(input, getResult, index);
                }
                else if (currentCharacterIsANumber && getResult > 0)
                {
                    second = GetSecondNumber(input, second, index, concatenateToSecondNumber);

                    concatenateToSecondNumber = NextCharacterIsANumber(input, index);

                    if (!concatenateToSecondNumber)
                    {
                        char op = stackOfOperators.Pop();
                        getResult = GetResult(op, getResult, second);
                    }

                }

                if (!currentCharacterIsANumber)
                {
                    stackOfOperators.Push(input[index]);
                    lastCharacterWasANumber = false;
                }
            }
            return getResult;
        }

        private static int GetFirstNumber(string input, int getResult, int currentCharacter)
        {
            return getResult > 0 ? Int32.Parse(getResult + input[currentCharacter].ToString()) : Int32.Parse(input[currentCharacter].ToString());
        }

        private static int GetSecondNumber(string input, int getResult, int currentCharacter, bool append)
        {
            return append && getResult > 0 ? Int32.Parse(getResult + input[currentCharacter].ToString()) : Int32.Parse(input[currentCharacter].ToString());
        }

        private bool NextCharacterIsANumber(string input, int currentCharacter)
        {
            var index = currentCharacter + 1;
            if (index < input.Length)
            {
                return Char.IsNumber(input[index]);
            }
            return false;
        }

        private int GetResult(char op, int first, int second)
        {
            Dictionary<char, Func<int>> operations = new Dictionary<char, Func<int>>
            {
                {'*',() => first * second },
                {'+',() => first + second },
                {'/',() => first / second },
                {'-',() => first - second },
            };
            return operations[op]();
        } 
    }
}