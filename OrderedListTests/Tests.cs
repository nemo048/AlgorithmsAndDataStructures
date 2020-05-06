using AlgorithmsDataStructures;
using Xunit;

namespace OrderedListTests
{
    public class Tests
    {
        #region Private methods

        private OrderedList<int> CreateOrderedList(bool ascending, params int[] values)
        {
            OrderedList<int> orderedList = new OrderedList<int>(ascending);

            for (int i = 0; i < values.Length; i++)
            {
                orderedList.Add(values[i]);
            }

            return orderedList;
        }

        private void CheckCorrectOrder(OrderedList<int> orderedList, bool ascending)
        {
            switch (orderedList.Count())
            {
            case 0:
                Assert.Null(orderedList.head);
                Assert.Null(orderedList.tail);
                return;
            case 1:
                Assert.Null(orderedList.head.prev);
                Assert.NotNull(orderedList.head);
                Assert.Null(orderedList.head.next);
                Assert.Null(orderedList.tail.prev);
                Assert.NotNull(orderedList.tail);
                Assert.Null(orderedList.tail.next);
                return;
            }
            
            Node<int> node = orderedList.head;
            
            if (ascending)
            {
                while (node != null)
                {
                    if (node.next != null)
                    {
                        Assert.True(node.next.value >= node.value);
                    }
                    
                    node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    if (node.next != null)
                    {
                        Assert.True(node.next.value <= node.value);
                    }

                    node = node.next;
                }
            }
        }

        #endregion
        
        [Fact]
        public void CreateOrderedListTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            CheckCorrectOrder(orderedListAsc, true);
            
            OrderedList<int> orderedListDesc = CreateOrderedList(
                false,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            CheckCorrectOrder(orderedListDesc, false);
        }

        [Fact]
        public void AddTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            orderedListAsc.Add(101);
            orderedListAsc.Add(50);
            orderedListAsc.Add(150);
            CheckCorrectOrder(orderedListAsc, true);
            Assert.Equal(13, orderedListAsc.Count());

            OrderedList<int> orderedListDesc = CreateOrderedList(
                false,
                9, 8, 1, 2, 3, 7, 6, 5, 4);
            orderedListDesc.Add(101);
            orderedListDesc.Add(50);
            orderedListDesc.Add(150);
            orderedListDesc.Add(0);
            
            CheckCorrectOrder(orderedListDesc, false);
            Assert.Equal(13, orderedListDesc.Count());
        }

        [Fact]
        public void ClearTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            orderedListAsc.Clear(true);
            
            Assert.Null(orderedListAsc.head);
            Assert.Null(orderedListAsc.tail);
        }

        [Fact]
        public void CountTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            Assert.Equal(10, orderedListAsc.Count());
        }

        [Fact]
        public void DeleteTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            Assert.Equal(10, orderedListAsc.Count());
            
            orderedListAsc.Delete(10);
            Assert.Equal(10, orderedListAsc.Count());
            
            orderedListAsc.Delete(9);
            Assert.Equal(9, orderedListAsc.Count());
        }

        [Fact]
        public void FindTest()
        {
            OrderedList<int> orderedListAsc = CreateOrderedList(
                true,
                0, 9, 8, 1, 2, 3, 7, 6, 5, 4);
            
            Assert.Null(orderedListAsc.Find(10));

            Node<int> node = orderedListAsc.Find(9);
            Assert.NotNull(node);
            
            Assert.Equal(9, node.value);
        }
    }
}