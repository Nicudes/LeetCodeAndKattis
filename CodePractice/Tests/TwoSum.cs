using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class TwoSum
    {

        //Brute Force through 

        public static int[] GetTheSumOf(int[] nums, int target)
        {
      
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = i; k < nums.Length; k++)
                {
                    if (nums[k] == target - nums[i])
                    {
                        if (k != i)
                        {
                            int[] returnList = new int[] { i, k };
                            return returnList;
                        }
                               
                    }

                }
            }
            return null;
        }

        public static void RunTest()
        {
            int[] nums = { 3,2,4};
            int target = 6;
            int[] output = GetTheSumOf(nums, target);
            Console.WriteLine("Input:");
            foreach (var i in nums)
            {
              
                Console.Write(i + ", ");
            }
            Console.WriteLine("[" + output[0] + "," + output[1] + "]");
        }
    }
}
