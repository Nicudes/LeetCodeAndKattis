using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class RomanToInt
    {

        public static int RomanToIntConvert(string s)
        {
            s = s.ToUpper();
            var total = 0;

            foreach (var i in s)
            {
                total += LetterConverter(i);
            }
            if (s.Contains("IV") || s.Contains("IX"))
            {
                total -= 2;
            }
            if (s.Contains("XL") || s.Contains("XC"))
            {
                total -= 20;
            }
            if (s.Contains("CM") || s.Contains("CD"))
            {
                total -= 200;
            }
            return total;
        }

        public static int LetterConverter(char romanChar)
        {
            switch (romanChar)
            {

                case 'M':
                    {
                        return 1000;
                    }
                case 'D':
                    {
                        return 500;
                    }
                case 'C':
                    {
                        return 100;
                    }
                case 'L':
                    {
                        return 50;
                    }
                case 'X':
                    {
                        return 10;
                    }
                case 'V':
                    {
                        return 5;
                    }
                case 'I':
                    {
                        return 1;
                    }

                default:
                    {
                        throw new ArgumentException("Character is not a roman number");
                    }
            }
        }


        public static void RunTest()
        {
            Console.WriteLine( RomanToIntConvert("IX"));
        }

    }
}
