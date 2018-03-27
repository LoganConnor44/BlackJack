using System;
using System.Collections.Generic;

namespace BlackJack
{
    public static class Extension
    {

        public static Random Random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int length = list.Count;
            while (length > 1)
            {
                length--;
                int index = Random.Next(length + 1);
                T value = list[index];
                list[index] = list[length];
                list[length] = value;
            }
        }
    }
}