using dsa.DataStructure.Queue;

namespace dsa.DataStructureTests.QueueImplTests
{
    public class QueueImplTests
    {
        private readonly QueueImpl<int> _queueInt;
        public QueueImplTests()
        {
            _queueInt = new QueueImpl<int>();
        }

        [Fact]
        public void TestEnqueueAndDequeue()
        {
            //Arrange
            var testData = new List<int> { 10, 21, 13, 24, 45, 79, 14, 57, 19, 17 };
            //Act
            foreach (var item in testData)
            {
                _queueInt.Enqueue(item);
            }
            var dequeueData1 = _queueInt.Dequeue(); // 1
            var dequeueData2 = _queueInt.Dequeue(); // 2
            
            _queueInt.Enqueue(110);
            _queueInt.Enqueue(122);
            _queueInt.Enqueue(128);
            var ite=_queueInt.Dequeue();
            
             Assert.Equal(testData[0], dequeueData1);
             Assert.Equal(testData[1], dequeueData2);
        }
        
        [Fact]
        public void TestEnqueueAndPeek()
        {
            //Arrange
            var testData = new List<int> { 10, 21, 13, 24, 45, 79, 14, 57, 19, 17 };
            //Act
            foreach (var item in testData)
            {
                _queueInt.Enqueue(item);
            }
            var dequeueData1 = _queueInt.Dequeue(); // 1
            var dequeueData2 = _queueInt.Dequeue(); // 2
            
            var peekItem = _queueInt.Peek();

            Assert.Equal(testData[2], peekItem);
        }
        
        [Fact]
        public void TestEnqueueAndClear()
        {
            //Arrange
            var testData = new List<int> { 10, 21, 13, 24, 45, 79, 14, 57, 19, 17 };
            //Act
            foreach (var item in testData)
            {
                _queueInt.Enqueue(item);
            }
            _queueInt.Clear();
            int size = _queueInt.Size();
            Assert.Equal(0, size);
        }
        
        [Fact]
        public void TestEnqueueAndIsEmpty()
        {
            //Arrange
            var testData = new List<int> { 10, 21, 13, 24, 45, 79, 14, 57, 19, 17 };
            //Act
            foreach (var item in testData)
            {
                _queueInt.Enqueue(item);
            }
            _queueInt.Clear();
            bool isEmpty = _queueInt.IsEmpty();
            Assert.True(isEmpty);
        }
    }
}
        