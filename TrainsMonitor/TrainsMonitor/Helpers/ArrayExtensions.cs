using System;

namespace TrainsMonitor.Helpers
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static T[] Reverse<T>(this T[] array)
        {
            Array.Reverse(array);
            return array;
        }
    }
}