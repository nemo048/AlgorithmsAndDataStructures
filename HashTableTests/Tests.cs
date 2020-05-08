using System;
using AlgorithmsDataStructures;
using Xunit;

namespace HashTableTests
{
    public class Tests
    {
        [Fact]
        public void HashFunTest()
        {
            HashTable hashTable = new HashTable(17, 3);

            int index = hashTable.HashFun("hello world");
        }
    }
}