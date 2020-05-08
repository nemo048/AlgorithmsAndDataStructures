using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string [] slots; 

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for(int i=0; i<size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {    
            // всегда возвращает корректный индекс слота
            return Math.Abs(value.GetHashCode()) % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1

            int index = HashFun(value);

            int firstIndex = index;
            while (slots[index] != null)
            {
                index = (index + step) % size;

                if (index == firstIndex)
                {
                    return -1;
                }
            }

            return index;
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            int index = SeekSlot(value);

            if (index == -1)
            {
                return -1;
            }
            
            slots[index] = value;
            return index;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            int index = HashFun(value);

            if (slots[index] == value)
            {
                return index;
            }

            int firstIndex = index;
            while (slots[index] != value)
            {
                index = (index + step) % size;

                if (index == firstIndex)
                {
                    return -1;
                }
            }

            return index;
        }
    }
 
}