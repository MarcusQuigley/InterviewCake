using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.InterviewCake
{
   public class InterviewCakeGreedy
    {
        //https://www.interviewcake.com/question/csharp/stock-price?course=fc1&section=greedy
        //  int[] stockPrices = { 10, 7, 5, 8, 11, 9 };
        public int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices==null)throw new ArgumentNullException(nameof(stockPrices));

            if (stockPrices.Length < 2)
                throw new ArgumentException("Getting a profit requires at least 2 prices",nameof(stockPrices));

            int maxProfit = int.MinValue;
            int min = stockPrices[0];
            for (int i = 1; i < stockPrices.Length; i++)
            {
                var price = stockPrices[i];
                maxProfit = Math.Max(maxProfit, price - min);
                min = Math.Min(min, price);
            }
            return maxProfit;
        }
    }
}
