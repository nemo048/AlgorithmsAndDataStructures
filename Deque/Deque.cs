using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        private LinkedList<T> _linkedList;
        
        public Deque()
        {
            // инициализация внутреннего хранилища
            _linkedList = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            // добавление в голову
            _linkedList.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            _linkedList.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (_linkedList.Count == 0)
            {
                return default(T);
            }

            T item = _linkedList.First.Value;
            _linkedList.RemoveFirst();

            return item;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if (_linkedList.Count == 0)
            {
                return default(T);
            }

            T item = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            
            return item;
        }
        
        public int Size()
        {
            return _linkedList.Count; // размер очереди
        }
    }

}