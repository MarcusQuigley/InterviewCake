using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCake.Arrays
{
    public class ArrayQuestions
    {
        
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
        //https://www.interviewcake.com/question/csharp/merge-sorted-arrays?course=fc1&section=array-and-string-manipulation
        public int[] MergeSortedArray(int[] array1, int[] array2)
        {
            var n = array1.Length + array2.Length;
            var results = new int[n];
            var leftPointer = 0;
            var rightPointer = 0;
            var count = 0;
            while (leftPointer < array1.Length && rightPointer < array2.Length)
            {
                if (array1[leftPointer] < array2[rightPointer])
                {
                    results[count] = array1[leftPointer];
                    leftPointer += 1;
                }
                else
                {
                    results[count] = array2[rightPointer];
                    rightPointer += 1;
                }
                count += 1;
            }
            if (leftPointer == array1.Length) {
                for (int i = rightPointer; i < array2.Length; i++)
                {
                    results[count++] = array2[i];
                }
            }
            else
            {
                for (int i = leftPointer; i < array1.Length; i++)
                {
                    results[count++] = array1[i];
                }
            }
            return results;
        }

        //https://www.interviewcake.com/question/csharp/cafe-order-checker?course=fc1&section=array-and-string-manipulation
        public bool CafeOrderChecker(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            if (takeOutOrders == null || dineInOrders == null || servedOrders == null) throw new ArgumentNullException("somethings null!!");
            if (takeOutOrders.Length + dineInOrders.Length != servedOrders.Length) return false;

            var takeOutIndex = 0;
            var dineInIndex = 0;
            var toValue=0;
            var diValue = 0;

            for (int servedOrdersIndex = 0; servedOrdersIndex < servedOrders.Length; servedOrdersIndex++)
            {
                toValue = (takeOutIndex < takeOutOrders.Length) ? takeOutOrders[takeOutIndex] : int.MaxValue;
                diValue = (dineInIndex < dineInOrders.Length) ? dineInOrders[dineInIndex] : int.MaxValue;
                var servedorder = servedOrders[servedOrdersIndex];
                
                if (toValue < diValue)
                {
                    if (servedorder != toValue)
                        return false;
                    takeOutIndex += 1;
                }
                else
                {
                    if (servedorder != diValue)
                        return false;
                    dineInIndex += 1;
                }
            }
            return true;
        }
    }
}
