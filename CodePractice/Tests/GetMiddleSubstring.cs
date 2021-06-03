using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class GetMiddleSubstring
    {

        public static string RunMidString(string s)
        {
            int offset = s.Length % 2 == 0 ? 1 : 0;
            string newString = s.Substring(s.Length / 2 - offset, offset +1);


            return newString;
        }

        public static void RunTest()
        {
            string result = RunMidString("Halfi");
            string expected = "l";

            string output = result == expected ? "True" : "False";
            Console.WriteLine(output);
        }
    }
}
