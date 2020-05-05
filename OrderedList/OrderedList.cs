using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private int _count;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            if(typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                return String.CompareOrdinal(
                    v1.ToString().Trim(), 
                    v2.ToString().Trim());
            }
            
            // универсальное сравнение
            int first = Convert.ToInt32(v1);
            int second = Convert.ToInt32(v2);
            
            if (first == second)
            {
                return 0;
            }
            
            if (first < second)
            {
                return -1;
            }

            return 1;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        private bool InsertBetween(Node<T> prev, Node<T> node, Node<T> next)
        {
            if (_ascending)
            {
                if (prev == null &&
                    next != null &&
                    Compare(node.value, next.value) <= 0)
                {
                    node.next = next;
                    node.prev = null;
                    next.prev = node;
                    head = node;
                    
                    return true;
                }

                if (prev != null &&
                    next == null &&
                    Compare(prev.value, node.value) <= 0)
                {
                    prev.next = node;
                    node.prev = prev;
                    node.next = null;
                    tail = node;

                    return true;
                }

                if (prev != null &&
                    next != null &&
                    Compare(prev.value, node.value) <= 0 &&
                    Compare(node.value, next.value) <= 0)
                {
                    node.prev = prev;
                    node.next = next;
                    prev.next = node;
                    next.prev = node;

                    return true;
                }
                
                if (next != null &&
                    next.next == null &&
                    Compare(next.value, node.value) <= 0)
                {
                    next.next = node;
                    node.prev = next;
                    tail = node;

                    return true;
                }
            }
            else
            {
                if (prev == null &&
                    next != null &&
                    Compare(node.value, next.value) >= 0)
                {
                    node.next = next;
                    node.prev = null;
                    next.prev = node;
                    head = node;
                    
                    return true;
                }

                if (prev != null &&
                    next == null &&
                    Compare(prev.value, node.value) >= 0)
                {
                    prev.next = node;
                    node.prev = prev;
                    node.next = null;
                    tail = node;

                    return true;
                }

                if (prev != null &&
                    next != null &&
                    Compare(prev.value, node.value) >= 0 &&
                    Compare(node.value, next.value) >= 0)
                {
                    node.prev = prev;
                    node.next = next;
                    prev.next = node;
                    next.prev = node;

                    return true;
                }
            }

            return false;
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию
            
            Node<T> node = new Node<T>(value);

            if (head == null)
            {
                head = node;
                tail = node;
                _count++;
                
                return;
            }

            Node<T> currentNode = head;

            while (currentNode != null)
            {
                if (InsertBetween(
                    currentNode.prev,
                    node,
                    currentNode))
                {
                    _count++;
                    return;
                }
                
                currentNode = currentNode.next;
            }
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            
            while (node != null)
            {
                int compareResult = Compare(node.value, val);
                
                if (_ascending && compareResult > 0 ||
                    !_ascending && compareResult < 0)
                {
                    return null;
                }
                
                if (compareResult == 0)
                {
                    return node;
                }

                node = node.next;
            }
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            // здесь будет ваш код
            if (_count == 0)
            {
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                if (Compare(current.value, val) == 0)
                {
                    _count--;
                    
                    if (current.prev == null)
                    {
                        if (current.next == null)
                        {
                            head = null;
                            tail = null;
                            return;
                        }

                        current.next.prev = null;
                        head = current.next;
                        current.next = null;
                    }
                    else
                    {
                        if (current.next == null)
                        {
                            current.prev.next = null;
                            tail = current.prev;
                            current.prev = null;
                            return;
                        }

                        current.prev.next = current.next;
                        current.next.prev = current.prev;
                        current = null;
                    }
                    
                    return;
                }
                current = current.next;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            // здесь будет ваш код
            while (head != null && tail != null)
            {
                if (head.next != null)
                {
                    head.next.prev = null;
                    head = head.next;
                    continue;
                }
                
                head = null;
                tail = null;
            }

            _count = 0;
        }

        public int Count()
        {
            return _count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
            // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while(node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }
 
}