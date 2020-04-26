using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList2Tests
{
    public class NodeValueEqualityComparer : IEqualityComparer<Node>
    {
        /// <inheritdoc />
        public bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            
            if (first == null || second == null)
            {
                return false;
            }
            
            return first.value == second.value;
        }

        /// <inheritdoc />
        public int GetHashCode(Node obj)
        {
            return obj.value;
        }
    }
    
    public class Tests
    {
        #region Universal methods

        private Node[] BuildNodes(params int[] values)
        {
            Node[] nodes = new Node[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                nodes[i] = new Node(values[i]);
            }

            return nodes;
        }
        
        private LinkedList2 GetLinkedList(params Node[] nodes)
        {
            LinkedList2 list = new LinkedList2();
            for (int i = 0; i < nodes.Length; i++)
            {
                list.AddInTail(nodes[i]);
            }

            switch (nodes.Length)
            {
                case 0:
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                    break;
                case 1:
                    Assert.NotNull(list.head);
                    Assert.Null(list.head.prev);
                    Assert.Null(list.head.next);
                    Assert.NotNull(list.tail);
                    Assert.Null(list.tail.prev);
                    Assert.Null(list.tail.next);
                    break;
                default:
                    Assert.NotNull(list.head);
                    Assert.Null(list.head.prev);
                    Assert.NotNull(list.head.next);
                    Assert.NotNull(list.tail);
                    Assert.NotNull(list.tail.prev);
                    Assert.Null(list.tail.next);
                    break;
            }

            return list;
        }

        private void CheckPrevAndNextCorrectness(LinkedList2 list, int length)
        {
            switch (length)
            {
                case 0:
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                    return;
                case 1:
                    Assert.Same(list.head, list.tail);
                    Assert.Null(list.head.prev);
                    Assert.Null(list.head.next);
                    Assert.Null(list.tail.prev);
                    Assert.Null(list.tail.next);
                    return;
                default:
                    Assert.NotNull(list.head);
                    Assert.Null(list.head.prev);
                    Assert.NotNull(list.head.next);
                    Assert.NotNull(list.tail);
                    Assert.NotNull(list.tail.prev);
                    Assert.Null(list.tail.next);
                    
                    Node node = list.head;
                    while (node != null)
                    {
                        if (node.next != null)
                        {
                            Assert.Same(node, node.next.prev);
                        }
                        node = node.next;
                    }
                    break;
            }
        }
        
        private void RemoveTest(int valueToRemove, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);
            int nodesToRemove = nodes.Count(node => node.value == valueToRemove) >= 1 ? 1 : 0;
            Node expectedHead = nodes.FirstOrDefault(node => node.value != valueToRemove) ??
                                nodes.Where(node => node.value == valueToRemove).Skip(1).FirstOrDefault();
            Node expectedTail = expectedHead == null ? 
                null : 
                nodes.LastOrDefault();

            bool removeSuccess = list.Remove(valueToRemove);
            
            Assert.True(nodesToRemove == 0 && !removeSuccess || 
                        nodesToRemove == 1 && removeSuccess);
            Assert.Equal(nodes.Length - nodesToRemove, list.Count());
            Assert.Same(expectedHead, list.head);
            Assert.Same(expectedTail, list.tail);

            CheckPrevAndNextCorrectness(list, nodes.Length - nodesToRemove);
        }

        private void RemoveAllTest(int valueToRemove, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);

            int nodesToRemove = nodes.Count(node => node.value == valueToRemove);
            Node expectedHead = nodes.FirstOrDefault(node => node.value != valueToRemove);
            Node expectedTail = nodes.LastOrDefault(node => node.value != valueToRemove);
            
            list.RemoveAll(valueToRemove);

            Assert.Equal(nodes.Length - nodesToRemove, list.Count());
            
            Assert.Same(expectedHead, list.head);
            Assert.Same(expectedTail, list.tail);

            CheckPrevAndNextCorrectness(list, nodes.Length - nodesToRemove);
        }

        private void FindTest(int valueToFind, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);

            Node expectedNode = nodes.FirstOrDefault(n => n.value == valueToFind);
            
            Assert.Same(expectedNode, list.Find(valueToFind));
        }

        private void FindAllTest(int valueToFind, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);

            IEnumerable<Node> expectedNodes = nodes.Where(node => node.value == valueToFind);
            
            Assert.True(expectedNodes.SequenceEqual(
                list.FindAll(valueToFind),
                new NodeValueEqualityComparer()));
        }

        private void InsertAfterTest(Node nodeToInsert, int nodeAfterNumber, params Node[] nodes)
        {
            Node nodeAfter = nodeAfterNumber < nodes.Length ? nodes[nodeAfterNumber] : null;

            LinkedList2 list = GetLinkedList(nodes);

            Node expectedHead = nodeAfterNumber == 0 ? 
                nodeAfter ?? nodeToInsert : 
                list.head;
            Node expectedTail = nodeAfterNumber == nodes.Length - 1 || nodes.Length == 0 ? nodeToInsert : list.tail;
            
            list.InsertAfter(nodeAfter, nodeToInsert);

            if (nodeAfter != null)
            {
                Assert.Same(nodeAfter.next, nodeToInsert);
            }
            Assert.Same(expectedHead, list.head);
            Assert.Same(expectedTail, list.tail);
            
            CheckPrevAndNextCorrectness(list, nodes.Length + 1);
        }

        private void AddInHeadTest(Node nodeToInsert, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);

            Node expectedHead = nodeToInsert;
            Node expectedTail = nodes.LastOrDefault() ?? nodeToInsert;
            
            list.AddInHead(nodeToInsert);
            
            Assert.Same(expectedHead, list.head);
            Assert.Same(expectedTail, list.tail);
            
            CheckPrevAndNextCorrectness(list, nodes.Length + 1);
        }
        
        private void ClearTest(params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);
            
            list.Clear();
            
            Assert.Null(list.head);
            Assert.Null(list.tail);
        }

        private void CountTest(int expectedLength, params Node[] nodes)
        {
            LinkedList2 list = GetLinkedList(nodes);
            
            Assert.Equal(expectedLength, list.Count());
        }

        #endregion

        [Fact]
        public void FindTest()
        {
            FindTest(0);
            FindTest(1, BuildNodes(1));
            FindTest(1, BuildNodes(2));
            FindTest(0, BuildNodes(0, 1, 2));
            FindTest(0, BuildNodes(0, 0, 0));
            FindTest(0, BuildNodes(0, 1, 0));
        }

        [Fact]
        public void FindAllTest()
        {
            FindAllTest(0);
            FindAllTest(1, BuildNodes(1));
            FindAllTest(1, BuildNodes(2));
            FindAllTest(0, BuildNodes(0, 1, 2));
            FindAllTest(0, BuildNodes(0, 0, 0));
            FindAllTest(0, BuildNodes(0, 1, 0));
        }
        
        [Fact]
        public void RemoveTest()
        {
            RemoveTest(0);
            RemoveTest(1, BuildNodes(1));
            RemoveTest(1, BuildNodes(2));
            RemoveTest(0, BuildNodes(0, 1, 2));
            RemoveTest(0, BuildNodes(0, 0, 0));
            RemoveTest(0, BuildNodes(0, 1, 0));
        }

        [Fact]
        public void RemoveAllTest()
        {
            RemoveAllTest(0);
            RemoveAllTest(1, BuildNodes(1));
            RemoveAllTest(1, BuildNodes(2));
            RemoveAllTest(0, BuildNodes(0, 1, 2));
            RemoveAllTest(0, BuildNodes(0, 0, 0));
            RemoveAllTest(0, BuildNodes(0, 1, 0));
        }

        [Fact]
        public void InsertAfterTest()
        {
            InsertAfterTest(new Node(0), 0);
            InsertAfterTest(new Node(0), 0, BuildNodes(1));
            InsertAfterTest(new Node(0), 2, BuildNodes(1, 2, 3));
            InsertAfterTest(new Node(0), 1, BuildNodes(1, 2, 3));
        }

        [Fact]
        public void AddInHead()
        {
            AddInHeadTest(new Node(0));
            AddInHeadTest(new Node(0), BuildNodes(1));
            AddInHeadTest(new Node(0), BuildNodes(1, 2, 3));
            AddInHeadTest(new Node(0), BuildNodes(1, 2, 3));
        }

        [Fact]
        public void ClearTest()
        {
            ClearTest(BuildNodes());
            ClearTest(BuildNodes(0, 1, 2));
        }

        [Fact]
        public void CountTest()
        {
            CountTest(0, BuildNodes());
            CountTest(1, BuildNodes(1));
            CountTest(3, BuildNodes(0, 0, 0));
        }
    }
}