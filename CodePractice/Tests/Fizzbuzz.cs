using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class Fizzbuzz
    {

        public static IList<string> FizzBuzz(int n)
        {

            List<String> answer = new List<String>();

            for (int i = 1; i <= n; i++)
            {

                if (i % 3 == 0 && i % 5 == 0)
                {
                    answer.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    answer.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    answer.Add("Buzz");
                }

                else
                {
                    answer.Add(i.ToString());
                }
            }
            return answer;

        }

        public static void RuntTest()
        {

            IList<string> fizzBuzzResult =FizzBuzz(45);

            foreach (var i in fizzBuzzResult)
            {
                Console.WriteLine(i);
            }
        }
    }
}
