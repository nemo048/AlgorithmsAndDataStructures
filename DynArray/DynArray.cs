using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T [] array;
        public int count;
        public int capacity;
        
        private const int MIN_CAPACITY = 16;
        private float _fillPercent = 0.5f;
        
        public DynArray()
        {
            count = 0;
            MakeArray(MIN_CAPACITY);
        }

        public void MakeArray(int new_capacity)
        {
            // ваш код
            capacity = new_capacity < MIN_CAPACITY ? MIN_CAPACITY : new_capacity;
            T[] newArray = new T[capacity];
            if (array != null)
            {
                Array.Copy(array, newArray, count);
            }
            array = newArray;
        }

        public T GetItem(int index)
        {
            if (index >= capacity || index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            // ваш код
            return array[index];
        }

        public void Append(T itm)
        {
            // ваш код
            if (count >= capacity)
            {
                MakeArray(capacity * 2);
            }
            array[count++] = itm;
        }

        public void Insert(T itm, int index)
        {
            // ваш код
            if (index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count + 1 > capacity)
            {
                MakeArray(capacity * 2);
            }

            T old = array[index];
            array[index] = itm;
            
            for (int i = index + 1; i < count + 1; i++)
            {
                T temp = array[i];
                array[i] = old;
                old = temp;
            }

            count++;
        }

        public void Remove(int index)
        {
            // ваш код
            if (index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            count--;
            T old = array[count];
            array[count] = default(T);

            for (int i = count - 1; i >= index; i--)
            {
                T temp = array[i];
                array[i] = old;
                old = temp;
            }

            if ((float) (count - 1) / capacity < _fillPercent)
            {
                MakeArray((int)(capacity / 1.5));
            }
        }

    }
}