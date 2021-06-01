using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class Reverse_Integer
    {
        public int Reverse(int x)
        {
            bool isMinus = x < 0 ? true : false;


            long reversedX = 0;

            int lastNum = 0;

            if (isMinus)
            {
                x = x * -1;
            }

            while (x >= 1)
            {
                lastNum = x % 10;

                reversedX = reversedX * 10 + lastNum;

                x = x / 10;
            }


            if (reversedX > Math.Pow(2, 31))
            {
                return 0;
            }

            else
            {

                return isMinus == true ? (int)reversedX * -1 : (int)reversedX;
            }
        }

        public void runtTest()
        {
            Reverse(-321);
            Reverse(0);
            Reverse(123);
        }

    }
}
