using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FBQuestions
{
    public class LeetFBQuestionsClasses
    {

        // 157 https://leetcode.com/problems/read-n-characters-given-read4/
        //Easy
        public int Read(char[] buf, int n, string characters)
        {
            charsToRead = characters;
            int copiedChars = 0;
            int readChars = 4;
            char[] buf4 = new char[4];

            while(copiedChars < n && readChars == 4)
            {
                readChars = Read4(buf4);
                for (int i = 0; i < readChars; i++)
                {
                    buf[copiedChars++] = buf4[i];
                    if (copiedChars == n)
                        break;
                }
            }
            return copiedChars;
        }
 
        string charsToRead;
        int charsReadPtr;
        int readSize = 4;
        int Read4(char[] buf4)
        {
       
            if (charsReadPtr < charsToRead.Length)
            {
                charsReadPtr += readSize;
                return charsReadPtr < charsToRead.Length  ? readSize : readSize - (charsReadPtr - charsToRead.Length );
            }
            return 0;
        }
    }
}
