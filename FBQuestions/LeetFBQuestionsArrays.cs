using System;
using System.Collections.Generic;
using System.Text;

namespace FBQuestions
{
    public class LeetFBQuestionsArrays
    {
        //953 https://leetcode.com/problems/verifying-an-alien-dictionary/
        //Easy
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words == null || string.IsNullOrEmpty(order))
                return false;
            Dictionary<char, int> map = new Dictionary<char, int>();
             for (int i = 0; i < order.Length; i++)
                map.Add(order[i], i);

            var endIndex = 0;
            var col = 0;
            var index = 0;
            while (endIndex < words.Length)
            {
                 var rowsChecked =0;
                var tempIndex = index;
                for (int row = 0; row < words.Length; row++)
                {
                     if (words[row].Length-1 >= col)
                    {
                        var @char = words[row][col];
                        var orderIndex = map[@char];
                        if (orderIndex < index)
                            return false;
                        index = orderIndex;
                        if (words[row].Length-1 == col)
                            endIndex++;
                        rowsChecked++;
                    }
                    //else
                    //{
                    //    if (row != endIndex)
                    //        return false;
                    //    //if (endIndex++ == words.Length)
                    //    //    return true;
                    //}
                }
                //need to check here for something..
                if (rowsChecked == (index - tempIndex))
                    return true;
                col++;
            }
            return true;
        }
    }
}
