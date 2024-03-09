using System.Collections.Generic;

namespace Common
{
    public class Range<T>
    {
        public T Min { get; set; }
        public T Max{ get; set; }
        
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
        
        public bool IsInRange(T value)
        {
            return Comparer<T>.Default.Compare(value, Min) >= 0 && Comparer<T>.Default.Compare(value, Max) <= 0;
        }
    }
}