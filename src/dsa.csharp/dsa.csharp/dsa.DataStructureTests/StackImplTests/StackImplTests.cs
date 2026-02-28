using dsa.DataStructure.Stack;

namespace dsa.DataStructureTests.StackImplTests
{
    public class StackImplTests
    {
        private readonly StackImpl<int> _stackInt;

        public StackImplTests()
        {
            _stackInt = new StackImpl<int>();
        }

        [Fact]
        public void TestPushAndPop()
        {
            //Arrange
            var testData = new List<int> { 1, 2, 3, 4, 5, 9, 4, 7, 19, 17 };

            //Act
            foreach (var item in testData)
            {
                _stackInt.Push(item);
            }
            var popData1 = _stackInt.Pop(); // 5
            var popData2 = _stackInt.Pop(); //4

            //Assert
            Assert.Equal(testData[testData.Count - 1], popData1);
            Assert.Equal(testData[testData.Count - 2], popData2);
        }
    }
}