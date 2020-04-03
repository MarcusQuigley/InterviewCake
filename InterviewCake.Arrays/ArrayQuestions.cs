using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCake.Arrays
{
    public class ArrayQuestions
    {
        public int FindNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;
            var result = 0;

            //foreach (var number in numbers){
            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                var counter = 0;
                while (number > 0)
                {
                    number /= 10;
                    counter += 1;
                }
                if (counter % 2 == 0) result += 1;
            }

            return result;
        }
        //https://www.interviewcake.com/question/csharp/merging-ranges?course=fc1&section=array-and-string-manipulation
        public Meeting[] InHouseCalendar(Meeting[] times)
        {
            if (times == null) throw new ArgumentNullException(nameof(times));
            if (times.Length < 2) return times;

            Array.Sort(times, new MeetingStartComparer());
            List<Meeting> results = new List<Meeting>();
            results.Add(times[0]);
            for (int i = 1; i < times.Length; i++)
            {
                var leftMeeting = results.Last();
                var rightMeeting = times[i];
                if (leftMeeting.EndTime >= rightMeeting.StartTime)
                {
                    leftMeeting.EndTime = Math.Max(leftMeeting.EndTime, rightMeeting.EndTime);
                }
                else
                {
                    results.Add(rightMeeting);
                }
            }
            return results.ToArray();
        }

        //https://www.interviewcake.com/question/csharp/reverse-string-in-place?course=fc1&section=array-and-string-manipulation
        public string ReverseString(string toReverse)
        {
            if (toReverse == null) throw new ArgumentNullException(nameof(toReverse));
            if (toReverse.Length == 1) return toReverse;
            
            var charArray = toReverse.ToCharArray();
            var first = 0;
            var last = charArray.Length-1;
            while(first< last)
            {
                var temp = charArray[first];
                charArray[first] = charArray[last];
                charArray[last] = temp;
                first += 1;
                last -= 1;
            }
            return new string(charArray);
        }

        //https://www.interviewcake.com/question/csharp/reverse-words?course=fc1&section=array-and-string-manipulation
        public string ReverseWords(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            var messageArray = message.ToCharArray();
            var n = messageArray.Length ;
             ReverseChars(messageArray,0, n-1);
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (messageArray[i] == ' ' )
                {
                    ReverseChars(messageArray, index, i-1);
                    index = i+1;
                }
                else if(i == n - 1)
                {
                    ReverseChars(messageArray, index, i );
                    //index = i + 1;
                }
            }
            return new string(messageArray);
        }

        void ReverseChars(char[] word, int start, int end)
        {
            while (start < end)
            {
                var temp = word[start];
                word[start] = word[end];
                word[end] = temp;
                start += 1;
                end -= 1;
            }
        }
    }
}
