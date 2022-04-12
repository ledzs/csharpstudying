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
            
            
            int temp = array[k];
            array[k] = array[l];
            array[l] = temp;

            return array;
        }
        
    }
}
