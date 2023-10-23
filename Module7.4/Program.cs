using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7._4
{
    public class ArrayClass
    {
        private int[] _array;

        public ArrayClass(int size)
        {
            _array = new int[size];
        }

        public ArrayClass(int[] arr)
        {
            _array = arr;
        }

        // Умножение массивов
        public static ArrayClass operator *(ArrayClass arr1, ArrayClass arr2)
        {
            int minLength = Math.Min(arr1._array.Length, arr2._array.Length);
            int[] result = new int[minLength];

            for (int i = 0; i < minLength; i++)
            {
                result[i] = arr1._array[i] * arr2._array[i];
            }

            return new ArrayClass(result);
        }

        // Доступ по индексу
        public int this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        // Размер массива
        public static explicit operator int(ArrayClass arr)
        {
            return arr._array.Length;
        }

        // Проверка на равенство
        public static bool operator ==(ArrayClass arr1, ArrayClass arr2)
        {
            return Enumerable.SequenceEqual(arr1._array, arr2._array);
        }

        public static bool operator !=(ArrayClass arr1, ArrayClass arr2)
        {
            return !(arr1 == arr2);
        }

        // Сравнение
        public static bool operator <=(ArrayClass arr1, ArrayClass arr2)
        {
            int minLength = Math.Min(arr1._array.Length, arr2._array.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (arr1._array[i] > arr2._array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            ArrayClass other = obj as ArrayClass;
            if (other == null) return false;

            return this == other;
        }

        public override int GetHashCode()
        {
            return _array.GetHashCode();
        }
    }

}
