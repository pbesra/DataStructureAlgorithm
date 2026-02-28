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
            //Assert
            Assert.Equal(testData[0], dequeueData1);
            Assert.Equal(testData[1], dequeueData2);
        }
    }
}
        