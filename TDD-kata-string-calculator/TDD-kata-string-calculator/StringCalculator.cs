
using System;
using System.Collections.Generic;

namespace TDD_kata_string_calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            if (numbers.Contains("//"))
            {
                var firstPartEndIndex = numbers.IndexOf('\n');
                var firstPart = numbers.Remove(firstPartEndIndex + 1);
                var delimiter = new char[] { firstPart[2] };

                numbers = numbers.Remove(0, firstPartEndIndex);

                return CountMany(numbers, delimiter);
            }

            if (numbers.Contains(',') || numbers.Contains('\n'))
            {
                return CountMany(numbers, new char[] { ',', '\n' });
            }

            var number = int.Parse(numbers);
            return number;
        }

        private static int CountMany(string numbers, char[] delimiters)
        {
            var numbersSplit = numbers.Split(delimiters);
            var negatives = new List<int>();
            var sum = 0;
            foreach (var numStr in numbersSplit)
            {
                var num = int.Parse(numStr);
                if (num < 0)
                {
                    negatives.Add(num);
                }
                if (num <= 1000)
                {
                    sum += num;
                }
            }

            if (negatives.Count > 0)
            {
                var exceptionMessage = "negatives not allowed:";
                for (var i = 0; i < negatives.Count; i++)
                {
                    var negative = negatives[i];
                    exceptionMessage += $" {negative}";
                    if (i < negatives.Count - 1)
                        exceptionMessage += ",";

                }
                throw new Exception(exceptionMessage);
            }

            return sum;
        }
    }
}
