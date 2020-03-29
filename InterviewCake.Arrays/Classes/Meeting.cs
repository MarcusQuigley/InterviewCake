using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace InterviewCake.Arrays
{
   public class Meeting
    {
        public Meeting(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }
    }

    public class MeetingStartComparer : IComparer<Meeting>
    {
        public int Compare( Meeting x, Meeting y)
        {
            return x.StartTime.CompareTo(y.StartTime);
        }
    }
}
