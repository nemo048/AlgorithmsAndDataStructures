using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value) { 
            value = _value; 
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;
        private int count;

        public LinkedList2()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) {
                head = _item;
                head.next = null;
                head.prev = null;
            } else {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
            
            count++;
        }

        public Node Find(int _value)
        {
            // здесь будет ваш код поиска
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            // здесь будет ваш код поиска всех узлов по заданному значению
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        private bool Remove(Node node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.prev == null)
            {
                if (node.next == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = node.next;
                    head.prev = null;
                    node.next = null;
                }
            }
            else if (node.next == null)
            {
                tail = node.prev;
                tail.next = null;
                node.prev = null;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
                node.next = null;
                node.prev = null;
                node = null;
            }

            count--;
            
            return true; 
        }

        public bool Remove(int _value)
        {
            // здесь будет ваш код удаления одного узла по заданному значению
            Node node = Find(_value);

            return Remove(node);
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            foreach (Node node in FindAll(_value))
            {
                Remove(node);
            }
        }

        public void Clear()
        {
            // здесь будет ваш код очистки всего списка
            Node node = head;

            while (node != null)
            {
                if (node.prev != null)
                {
                    node.prev.next = null;
                    node.prev = null;
                }
                node = node.next;
            }

            head = null;
            tail = null;
            count = 0;
        }

        public int Count()
        {
            return count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void AddInHead(Node node)
        {
            count++;

            if (head == null)
            {
                AddInTail(node);
                return;
            }

            node.next = head;
            head.prev = node;
            head = node;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного узла
            count++;
            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
            if (_nodeAfter == null)
            {
                if (count == 1)
                {
                    head = _nodeToInsert;
                    head.prev = null;
                    head.next = null;
                    tail = _nodeToInsert;
                    tail.prev = null;
                    tail.next = null;
                }
                else
                {
                    _nodeToInsert.next = head;
                    _nodeToInsert.prev = null;
                    
                    head.prev = _nodeToInsert;
                    head = _nodeToInsert;
                }

                return;
            }

            Node node = head;
            
            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    if (_nodeAfter == tail)
                    {
                        _nodeAfter.next = _nodeToInsert;
                        _nodeToInsert.prev = _nodeAfter;
                        tail = _nodeToInsert;
                    }
                    else
                    {
                        _nodeToInsert.next = _nodeAfter.next;
                        _nodeToInsert.prev = _nodeAfter;
                        _nodeAfter.next.prev = _nodeToInsert;
                        _nodeAfter.next = _nodeToInsert;
                    }
                    return;
                }

                node = node.next;
            }
        }

    }
}