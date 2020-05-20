using System;
using System.Collections.Generic;
using System.Text;

namespace Design.LeetCode.Medium
{
    //Leet M https://leetcode.com/problems/online-stock-span/
    public class StockSpanner
    {
        readonly Stack<PriceSpan> stackPrices = new Stack<PriceSpan>();
        public StockSpanner() { }

        public int Next(int price)
        {
            var priceSpan = new PriceSpan() { Price = price, Span = 1 };
            if (stackPrices.Count == 0 || stackPrices.Peek().Price > price)
            {
                stackPrices.Push(priceSpan);
            }
            else
            {
                while (stackPrices.Count > 0 && stackPrices.Peek().Price <= price)
                {
                    var ps = stackPrices.Pop();
                    priceSpan.Span += ps.Span;
                }
                stackPrices.Push(priceSpan);
            }
            return priceSpan.Span;
        }

        private struct PriceSpan
        {
            public int Price { get; set; }
            public int Span { get; set; }
            public override string ToString()
            {
                return $" {Price} {Span}";
            }
        }
    }
}
