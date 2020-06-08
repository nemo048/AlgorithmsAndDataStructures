using System.Collections.Generic;
using System;
using System.Collections;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray arr;

        public BloomFilter(int f_len)
        {
            arr = new BitArray(f_len);
            
            // создаём битовый массив длиной f_len ...
        }
        
        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = (code * 17) % arr.Length;
            }
            
            return result;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = (code * 223) % arr.Length;
            }

            return result;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            int hash1 = Hash1(str1);
            int hash2 = Hash2(str1);
            arr.Set(hash1,true);
            arr.Set(hash2,true);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int hash1 = Hash1(str1);
            int hash2 = Hash2(str1);
            
            return arr[hash1] && arr[hash2];
        }
    }
}