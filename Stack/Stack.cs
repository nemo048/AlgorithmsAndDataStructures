using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private LinkedList<T> _linkedList;
        
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            _linkedList = new LinkedList<T>();
        } 

        public int Size() 
        {
            // размер текущего стека		  
            return _linkedList.Count;
        }

        public T Pop()
        {
            // ваш код
            if (_linkedList.Count == 0)
            {
                return default(T); // null, если стек пустой
            }

            T item = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            
            return item;
        }
	  
        public void Push(T val)
        {
            // ваш код
            _linkedList.AddLast(val);
        }

        public T Peek()
        {
            // ваш код
            if (_linkedList.Count == 0)
            {
                return default(T); // null, если стек пустой
            }

            return _linkedList.Last.Value;
        }
    }

}