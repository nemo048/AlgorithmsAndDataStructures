using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private readonly DynArray<T> _array;
        
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            _array = new DynArray<T>();
        } 

        public int Size() 
        {
            // размер текущего стека		  
            return _array.count;
        }

        public T Pop()
        {
            // ваш код
            if (_array.count == 0)
            {
                return default(T); // null, если стек пустой
            }

            T item = _array.GetItem(_array.count - 1);
            _array.Remove(_array.count - 1);
            return item;
        }
	  
        public void Push(T val)
        {
            // ваш код
            _array.Append(val);
        }

        public T Peek()
        {
            // ваш код
            if (_array.count == 0)
            {
                return default(T); // null, если стек пустой
            }

            return _array.GetItem(_array.count - 1);
        }
    }

}