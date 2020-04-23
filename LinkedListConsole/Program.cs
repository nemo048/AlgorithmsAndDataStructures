using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmsDataStructures;

namespace LinkedListConsole
{
    internal class Program
    {
        private const char DELIMETER = '-';
        
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            
            // list.AddInTail(new Node(0));
            // list.AddInTail(new Node(1));
            // list.AddInTail(new Node(0));

            PrintAllNodes(list);

            Console.WriteLine(list.Count());
            
            PrintAllNodes(list);

            Console.ReadKey();
        }

        private static void PrintAllNodes(LinkedList list)
        {
            StringBuilder builder = new StringBuilder();
            Node node = list.head;
            if (node != null)
            {
                builder.Append(node.value);
                node = node.next;
            }

            while (node != null)
            {
                builder.Append(DELIMETER);
                builder.Append(node.value);
                node = node.next;
            }
            
            Console.WriteLine(builder.ToString());
        }
    }
}