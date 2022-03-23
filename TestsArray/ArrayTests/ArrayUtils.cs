using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeElements
{
    public class ArrayUtils
    {
        public static int[] ChangeElementsInArray(int[] array, int k, int l)
        {
            //3. Обмен местами двух элементов массива с заданными номерами (индексами)
            int[] arr = array;
            int first = k;//индекс
            int second = l;//индекс
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;

            return arr;
        }
        
    }
}
