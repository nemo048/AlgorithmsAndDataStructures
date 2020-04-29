using System;
using AlgorithmsDataStructures;
using Xunit;

namespace StackTests
{
    public class Tests
    {
        [Fact]
        public void PushTest()
        {
            Stack<int?> stack = new Stack<int?>();
            
            stack.Push(1);
            
            Assert.Equal(1, stack.Size());
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void SizeTest()
        {
            Stack<int> stack = new Stack<int>();
            
            stack.Push(1);
            Assert.Equal(1, stack.Size());
            stack.Push(2);
            Assert.Equal(2, stack.Size());
            stack.Push(3);
            Assert.Equal(3, stack.Size());
        }

        [Fact]
        public void PopTest()
        {
            Stack<int?> stack = new Stack<int?>();
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Null(stack.Pop());
        }

        [Fact]
        public void PeekTest()
        {
            Stack<int?> stack = new Stack<int?>();
            
            Assert.Null(stack.Peek());
            
            stack.Push(1);
            
            Assert.Equal(1, stack.Peek());
            Assert.Equal(1, stack.Peek());
        }
    }
}