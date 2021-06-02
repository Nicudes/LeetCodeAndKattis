using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class ValidParentheses
    {

        public static bool isValid(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];

                if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                {
                    stack.Push(currentChar);
                }
                else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var previous = (char)stack.Pop();

                    if ((previous == '(' && currentChar == ')') ||
                        (previous == '[' && currentChar == ']') ||
                        (previous == '{' && currentChar == '}'))
                    {
                        continue;
                    }

                    return false;
                }
            }

            return stack.Count == 0;
        }


        public static void RunTest()
        {
            bool isTrue = isValid("()()(()");

            if (isTrue)
            {
                Console.WriteLine("True");
            }
            if (!isTrue)
            {
                Console.WriteLine("False");
            }
        }

    }
}
