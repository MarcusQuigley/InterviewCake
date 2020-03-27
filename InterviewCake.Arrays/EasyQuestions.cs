using System;

namespace InterviewCake.Arrays
{
    public class Easy
    {
        public int FindNumbers(int[] numbers){
            if (numbers==null || numbers.Length==0)
                return -1;
            var result = 0;
            
            //foreach (var number in numbers){
            for(int i=0; i<numbers.Length;i++){
                var number = numbers[i];
                var counter =0;
                while (number > 0){
                    number /=10;
                    counter+=1;
                }
                if (counter%2==0) result+=1;
            }

            return result;
        }
    }
}
