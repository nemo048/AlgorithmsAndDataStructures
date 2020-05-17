using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int index = Math.Abs(key.GetHashCode()) % size;
            return index;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            return slots[this.HashFun(key)] != null;

        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            int index = this.HashFun(key);
            slots[index] = key;
            values[index] = value;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            return this.IsKey(key) ? values[this.HashFun(key)] : default(T);
        }
    }
}