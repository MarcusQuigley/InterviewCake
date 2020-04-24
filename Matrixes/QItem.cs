using System;
using System.Collections.Generic;
using System.Text;

namespace Matrixes
{
   public class BaseQItem
    {
        public BaseQItem(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        
    }

    public class QItem : BaseQItem
    {
        public QItem(int row, int col, int total)
            :base(row, col)
        {
            Total = total;
        }
        public int Total { get; set; }
    }
}
