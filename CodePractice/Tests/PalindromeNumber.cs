using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class PalindromeNumber
    {

        public static bool IsPalindrome(int x)
        {
            List<int> myIntList = new List<int>();
            string myNumberInString = x.ToString();
            string reversedNum = "";

            if (x < 0)
            {
                return false;
            }


            myIntList = myNumberInString.Select(x => Convert.ToInt32(x.ToString())).ToList();
            myIntList.Reverse();

            foreach (var i in myIntList)
            {
                reversedNum += i.ToString();
            }


         
            if (reversedNum == x.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public static void RunTest()
        {
            bool result = IsPalindrome(404);
            if (result)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            result = IsPalindrome(-404);
            if (result)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            result = IsPalindrome(1234567899);
            if (result)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }


        }

    }
}
