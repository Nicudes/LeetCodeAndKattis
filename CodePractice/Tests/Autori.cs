using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class Autori
    {
        public static string GetLetters()
        {
            char[] inputName = Console.ReadLine().ToCharArray();
            bool outputText = false;
            string WriteTheLine = "";

            Console.Write(inputName[0]);
            foreach (var i in inputName)
            {
                if (outputText)
                {
                    WriteTheLine += i;
                    outputText = false;
                }
                if (i == '-')
                {
                    outputText = true;
                }
            }
            return WriteTheLine;
        }

  
    }
}
