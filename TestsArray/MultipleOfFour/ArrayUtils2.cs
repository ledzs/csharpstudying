using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleOfFour
{
    public class ArrayUtils2
    {
        public static int[] MultipleFour(int[] array, int k)
        {
            //Задано число n, массив заполнен случайными числами. Вывести индексы элементов, кратных 4.
            int n = k;
            int[] newArray = new int[n];
            Random rand = new Random();
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = rand.Next(0, 100);
            }
            for (int i = 0; i < n; i++)
            {
                if (newArray[i] % 4 == 0)
                {
                    Console.WriteLine($"{i}:{newArray[i]}");
                }
            }
            return newArray;
        }
    }
}
