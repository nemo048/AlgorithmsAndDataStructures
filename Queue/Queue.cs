using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private LinkedList<T> _linkedList;
        
        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            _linkedList = new LinkedList<T>();
        } 

        public void Enqueue(T item)
        {
            // вставка в хвост
            _linkedList.AddLast(item);
        }

        public T Dequeue()
        {
            // выдача из головы
            if (_linkedList.Count == 0)
            {
                return default(T); // если очередь пустая
            }

            T item = _linkedList.First.Value;
            _linkedList.RemoveFirst();

            return item;
        }

        public int Size()
        {
            return _linkedList.Count; // размер очереди
        }
    }
}