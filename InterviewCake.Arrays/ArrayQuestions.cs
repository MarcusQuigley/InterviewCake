using System;
using System.Collections.Generic;

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

        public Meeting[] InHouseCalendar(Meeting[] times)
        {
            if (times == null) throw new ArgumentNullException(nameof(times));
            if (times.Length < 2) return times;

            Array.Sort(times, new MeetingStartComparer());

            var c = 0;
            Meeting meet1 = null;
            List<Meeting> results = new List<Meeting>();

            while (c < times.Length)
            {
                meet1 = times[c];
                for (int i = c + 1; i < times.Length; i++)
                {
                    var meet2 = times[i];
                    if (meet1.EndTime >= meet2.StartTime)
                        meet1.EndTime = meet2.EndTime;
                    else
                    {
                        results.Add(meet1);
                        c = i;
                        break;
                    }
                }
            }
            results.Add(meet1);
            return results.ToArray();
        }
    }
}
