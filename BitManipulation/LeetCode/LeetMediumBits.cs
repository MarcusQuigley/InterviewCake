using System;

namespace BitManipulation
{
    public class LeetMediumBits
    {

        //201 https://leetcode.com/problems/bitwise-and-of-numbers-range/
        public int RangeBitwiseAnd(int m, int n)
        {
            //by XORing the range ends, the first 0 needs to be filled to the right by zeroes.
            //This will give the same result if you add all the numbers in the range
            if (m == n)
                return m;
            var x = m ^ n; // this will contain the first zero
            var s = x >> 1; // right shift to create a diff number to x
            while (s > 0)
            {
                x = x | s; //keep oring thru the loop. This way we will result in a value that has all ones from where the first 0 was
                s = s >> 1;
            }
            return m & n & ~x;
        }
    }
}
