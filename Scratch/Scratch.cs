using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scratch
{
  public  class Scratch
    {
      public bool HasDuplicateUsingBits(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("Need a string to test");
            int checker = 0;
//            var sum = s[0]-'a';
            for(int i = 0; i < s.Length; i++)
            {
                int val = s[i] - 'a';
                if ((checker & (1 << val)) > 0)
                    return true;
                checker |= (1 << val);
            }
            return false;
        }
    }
}
