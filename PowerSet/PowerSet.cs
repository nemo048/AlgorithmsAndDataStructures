using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public Dictionary<T,bool> items;
        
        public PowerSet()
        {
            items = new Dictionary<T, bool>();
        }
        
        public int Size()
        {
            // количество элементов в множестве
            return items.Count;
        }

        
        public void Put(T value)
        {
            if (!items.ContainsKey(value))
            {
                items.Add(value, true);
            }
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            return items.ContainsKey(value);
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            if (items.ContainsKey(value))
            {
                return items.Remove(value);
            }

            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            var intersect = new PowerSet<T>();
            foreach (var item in items.Keys)
            {
                if (set2.Get(item))
                {
                    intersect.Put(item);
                }
            }
            return intersect;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            var union = new PowerSet<T>();
            foreach (var item in items.Keys)
            {
                union.Put(item);
            }
            foreach (var item in set2.items.Keys)
            {
                union.Put(item);
            }
            return union;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            var diff = new PowerSet<T>();
            foreach (var item in items.Keys)
            {
                if (!set2.Get(item))
                {
                    diff.Put(item);
                }
                
            }
            return diff;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            int size = this.Size();
            var union = this.Union(set2);

            return union.Size() == size;
        }
    }
}