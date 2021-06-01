using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class RunningSumof1dArray
    {
        public static int[] RunningSum(int[] nums)
        {

            //Hålla kolla på Running sums 
            int sum = 0;

            //En array för att hålla koll på nya värden
            int[] outputSums = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                // Öka Runningsum med värdet från indexen
                sum = sum + nums[i];
                //Lägg till i en ny array
                outputSums[i] = sum;
            }
            return outputSums;
        }

        public static void RunTest()
        {
            int[] nums = {1, 1, 1, 1, 1};
            int[] numsOutput = RunningSum(nums);

            foreach (var i in numsOutput)
            {
                Console.WriteLine(i);
            }




        }

        
    }
}
