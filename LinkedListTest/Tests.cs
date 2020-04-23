using System.Linq;
using AlgorithmsDataStructures;
using Xunit;

namespace LinkedListTest
{
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

        private LinkedList GetLinkedList(params Node[] nodes)
        {
            LinkedList list = new LinkedList();
            for (int i = 0; i < nodes.Length; i++)
            {
                list.AddInTail(nodes[i]);
            }

            if (nodes.Length == 0)
            {
                Assert.Null(list.head);
                Assert.Null(list.tail);
            }
            else
            {
                Assert.NotNull(list.head);
                Assert.NotNull(list.tail);
            }

            return list;
        }
        
        private void RemoveTest(int valueToRemove, params Node[] nodes)
        {
            LinkedList list = GetLinkedList(nodes);

            if (nodes.Count(node => node.value == valueToRemove) >= 1)
            {
                Assert.True(list.Remove(valueToRemove));
                Assert.Equal(nodes.Length - 1, list.Count());
                if (nodes.Length - 1 == 0)
                {
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                }
                else
                {
                    Assert.NotNull(list.head);
                    Assert.NotNull(list.tail);
                }
            }
            else
            {
                Assert.False(list.Remove(valueToRemove));
                Assert.Equal(nodes.Length, list.Count());
                if (nodes.Length == 0)
                {
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                }
                else
                {
                    Assert.NotNull(list.head);
                    Assert.NotNull(list.tail);
                }
            }
        }
        
        private void RemoveAllTest(int valueToRemove, params Node[] nodes)
        {
            LinkedList list = GetLinkedList(nodes);

            int numberOfNodesToRemove = nodes.Count(node => node.value == valueToRemove);
            list.RemoveAll(valueToRemove);

            if (numberOfNodesToRemove >= 1)
            {
                int expectedCount = nodes.Length - numberOfNodesToRemove;
                Assert.Equal(expectedCount, list.Count());
                if (expectedCount == 0)
                {
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                }
                else
                {
                    Assert.NotNull(list.head);
                    Assert.NotNull(list.tail);
                }
            }
            else
            {
                Assert.Equal(nodes.Length, list.Count());
                if (nodes.Length == 0)
                {
                    Assert.Null(list.head);
                    Assert.Null(list.tail);
                }
                else
                {
                    Assert.NotNull(list.head);
                    Assert.NotNull(list.tail);
                }
            }
        }

        #endregion

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
    }
}