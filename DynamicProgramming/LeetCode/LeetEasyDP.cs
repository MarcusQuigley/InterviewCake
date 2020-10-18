using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.LeetCode
{
    public class LeetEasyDP
    {
        //[7,1,5,3,6,4] ans 5
        //121 https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit(int[] prices)
        {
            if (prices == null) throw new ArgumentNullException(nameof(prices));
            if (prices.Length == 1) return 0;

            var minimum = int.MaxValue;
            var maxprofit = 0;
            var storage = new int[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                int price = prices[i];
                minimum = Math.Min(minimum, price);
                maxprofit = Math.Max(price - minimum, maxprofit);


            }
            return maxprofit;
        }
    }
}
