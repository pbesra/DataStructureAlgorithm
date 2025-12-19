using dsa.DataStructure.LinkedList;

namespace dsa.DataStructureTests.LinkedListTests
{
    public class SinglyLinkedListTests
    {
        private readonly SinglyLinkedList<int?> _singlyLinkedList;
        

        public SinglyLinkedListTests()
        {
            
            _singlyLinkedList = new SinglyLinkedList<int?>();
        }

        [Fact]
        public void TestAddAndPeek()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            //Assert
            var peekData = _singlyLinkedList.Peek();

            Assert.Equal(peekData, testData.Last());
        }

        [Fact]
        public void TestAddAndPop()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            var popData1=_singlyLinkedList.Pop();
            var popData2=_singlyLinkedList.Pop();
            //Assert

            Assert.Equal(testData[testData.Count - 1], popData1);
            Assert.Equal(testData[testData.Count - 2], popData2);
        }

        [Fact]
        public void TestAddAndRemove()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Remove();
            _singlyLinkedList.Remove();
            var peekData = _singlyLinkedList.Peek();
            //Assert

            Assert.Equal(testData[testData.Count - 3], peekData); // two removes
        }

        [Fact]
        public void TestAddAndClear()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Clear();
            var peekData = _singlyLinkedList.Peek();
            //Assert

            Assert.Null(peekData);
        }

        [Fact]
        public void PrintList_ShouldPrintAllNodesInOrder()
        {
            // Arrange
            var list = new SinglyLinkedList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            list.PrintList();
            var output = sw.ToString();

            // Assert
            Assert.Equal("1\n2\n3\n".Replace("\n", Environment.NewLine), output);
        }

        [Fact]
        public void Test_Size()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            var size = _singlyLinkedList.Size();
            //Assert
            Assert.Equal(testData.Count, size);
        }

        [Fact]
        public void Test_SizeWhenPop()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Pop();
            var size = _singlyLinkedList.Size();
            //Assert
            Assert.Equal(testData.Count-1, size);
        }

        [Fact]
        public void Test_SizeWhenClear()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Clear();
            var size = _singlyLinkedList.Size();
            //Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Test_SizeWhenClearAndPop()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Clear();
            var size = _singlyLinkedList.Size();
            var popItem = _singlyLinkedList.Pop();
            //Assert
            Assert.Null(popItem);
            Assert.Equal(0, size);
        }

        [Fact]
        public void Test_SizeWhenRemove()
        {
            //Arrange
            var testData = new List<int?> { 1, 2, 3, 4, 5 };
            //Act
            foreach (var item in testData)
            {
                _singlyLinkedList.Add(item);
            }
            _singlyLinkedList.Remove();
            var size = _singlyLinkedList.Size();
            //Assert
            Assert.Equal(testData.Count - 1, size);
        }
    }
}