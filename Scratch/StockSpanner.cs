using System;
using System.Collections.Generic;
using System.Text;

namespace Scratch
{
    //Leet M https://leetcode.com/problems/online-stock-span/
    public class StockSpanner
    {
        List<PriceSpan> previousPrices = new List<PriceSpan>();
        PriceSpan lastPrice;
        public StockSpanner()
        {

        }

        public int Next(int price)
        {
            var p = new PriceSpan();
            p.Price = price;
            p.Span = 1;
            // if (previousPrices.Count == 0 || lastPrice.Price >= price)

            //else
            if (previousPrices.Count>0 && price>= lastPrice.Price)
            {
                var pp = lastPrice;
                var currentindex = previousPrices.Count -1;
                while (price >= pp.Price)
                {
                    p.Span += pp.Span;
                    currentindex -= pp.Span;
                    if (currentindex < 0)
                        break;
                    pp = previousPrices[currentindex];
                }
            }
            lastPrice = p;
            previousPrices.Add(lastPrice);
            return lastPrice.Span;
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
