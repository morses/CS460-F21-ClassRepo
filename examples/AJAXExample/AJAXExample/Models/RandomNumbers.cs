using System;
using System.Collections.Generic;
using System.Linq;

namespace AJAXExample.Models
{
    public class RandomNumbers
    {
        public string Message { get; set; }
        public int Count { get; set; }
        public int Max { get; set; }
        public IEnumerable<int> Domain { get; set; }
        public IEnumerable<int> Range { get; set; }

        public RandomNumbers(string message, int count, int max)
        {
            if(count < 1 || max < 0)
            {
                throw new ArgumentOutOfRangeException("Parameter count must be greater than 0, or max must not be negative");
            }
            this.Message = message;
            this.Count = count;
            this.Max = max;

            Random generator = new Random();
            Domain = Enumerable.Range(1, count);
            Range = Enumerable.Range(1, count).Select(x => generator.Next(Max));
        }
    }
}