using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice
{
    class Scramble
    {
        public static void StartScramble()
        {
			var totals = new[]
	{
			RunTestCase("udwkcydwdu", "ducky", true),
			RunTestCase("ioancdgdjk", "coding", true),
			RunTestCase("fawfa3", "fries", false),
			RunTestCase("scriptjavx", "javascript", false),
			RunTestCase("scriptingjava", "javascript", true),
			RunTestCase("scriptsjava", "javascripts", true),
			RunTestCase("javscripts", "javascript", false),
			RunTestCase("aabbcamaomsccdd", "commas", true),
			RunTestCase("commas", "commas", true),
			RunTestCase("sammoc", "commas", true)
		};

			Console.WriteLine("\n" + totals.Count(x => x) + "/" + totals.Length + " passed");
		}

		public static bool ScrambleMe(string scrambled, string correct)
		{
			List<char> scramLetters = scrambled.ToList();
			bool isTrue = true;


			foreach (var i in correct)
			{
				if (!scramLetters.Contains(i))
				{
					isTrue = false;
					break;
				}
				else
				{
					scramLetters.Remove(i);
				}
			}



			return isTrue;

		}

		private static bool RunTestCase(string scrambled, string correct, bool expected)
		{
			var result = ScrambleMe(scrambled, correct);
			if (result != expected)
			{
				Console.WriteLine("Failed:\n\t " + scrambled + " - " + correct + " ---- Expected " + expected + " but got " + result);
				return false;
			}
			else
			{
				Console.WriteLine("OK!:\n\t " + scrambled + " - " + correct);
				return true;
			}
		}
	}
}
