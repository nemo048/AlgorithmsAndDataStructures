using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
            }
            else
            {
                tail.next = _item;
            }
            tail = _item;

            count++;
        }

        public Node Find(int _value)
        {
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

        public bool Remove(int _value)
        {
            // здесь будет ваш код удаления одного узла по заданному значению
            Node node = head;
            Node parent = null;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = node.next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else
                    {
                        parent.next = node.next;
                    }

                    count--;
                    return true;
                }

                parent = node;
                node = node.next;
            }
            return false; 
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            Node node = head;
            Node parent = null;
            
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = node.next;
                        if (head == null)
                        {
                            tail = null;
                        }

                        parent = null;
                    }
                    else
                    {
                        parent.next = node.next;
                        if (parent.next == null)
                        {
                            tail = parent;
                        }
                    }

                    count--;
                    node = node.next;
                    continue;
                }

                parent = node;
                node = node.next;
            }
        }

        public void Clear()
        {
            // здесь будет ваш код очистки всего списка
            while (head != null)
            {
                head = head.next;
            }

            tail = null;
            count = 0;
        }

        public int Count()
        {
            return count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            count++;
            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                return;
            }

            Node node = head;
            Node parent = null;
            
            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    if (node.next == null)
                    {
                        tail = node.next;
                    }
                    node.next = _nodeToInsert;
                    return;
                }

                node = node.next;
            }
        }
    }
}