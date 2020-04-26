using System;
using AlgorithmsDataStructures;
using Xunit;

namespace DynArrayTests
{
    public class Tests
    {
        private void MakeAppend(DynArray<int> array, int times)
        {
            for (int i = 0; i < times; i++)
            {
                array.Append(42);
            }
        }

        [Fact]
        public void AppendWithoutExtendBufferTest()
        {
            //вставка элемента, когда в итоге размер буфера не превышен (проверьте также размер буфера);
            DynArray<int> array = new DynArray<int>();

            array.Append(42);

            Assert.Equal(1, array.count);
            Assert.Equal(16, array.array.Length);
            Assert.Equal(42, array.GetItem(0));
            Assert.Equal(16, array.capacity);
        }

        [Fact]
        public void AppendWithExtendBufferTest()
        {
            //вставка элемента, когда в результате превышен размер буфера (проверьте также корректное изменение размера буфера);
            DynArray<int> array = new DynArray<int>();
            
            MakeAppend(array, 17);
            
            Assert.Equal(17, array.count);
            Assert.Equal(32, array.array.Length);
            for (int i = 0; i < array.count; i++)
            {
                Assert.Equal(42, array.GetItem(i));
            }
            Assert.Equal(32, array.capacity);
        }

        [Fact]
        public void InsertToIncorrectPositionTest()
        {
            //попытка вставки элемента в недопустимую позицию;
            DynArray<int> array = new DynArray<int>();
            
            MakeAppend(array, 6);

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(33, 8));
        }

        [Fact]
        public void RemoveWithoutDecreaseBufferSizeTest()
        {
            //удаление элемента, когда в результате размер буфера остаётся прежним (проверьте также размер буфера);
            DynArray<int> array = new DynArray<int>();
            
            MakeAppend(array, 4);
            
            array.Append(33);
            
            MakeAppend(array, 4);
            
            array.Remove(4);
            
            Assert.Equal(8, array.count);
            Assert.Equal(16, array.array.Length);
            Assert.Equal(42, array.GetItem(4));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.GetItem(9));
            Assert.Equal(16, array.capacity);
        }

        [Fact]
        public void RemoveWithDecreaseBufferSizeTest()
        {
            //удаление элемента, когда в результате понижается размер буфера (проверьте также корректное изменение размера буфера);
            DynArray<int> array = new DynArray<int>();
            
            MakeAppend(array, 12);
            
            array.Append(33);
            
            MakeAppend(array, 4);
            
            array.Remove(12);
            
            Assert.Equal(16, array.count);
            Assert.Equal(21, array.array.Length);
            Assert.Equal(42, array.GetItem(12));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.GetItem(22));
            Assert.Equal(21, array.capacity);
        }

        [Fact]
        public void RemoveFromIncorrectPositionTest()
        {
            //попытка удаления элемента в недопустимой позиции.
            DynArray<int> array = new DynArray<int>();
            
            MakeAppend(array, 6);

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Remove(7));
        }
    }
}