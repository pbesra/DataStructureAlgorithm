using dsa.Algorithms.DesignPatterns.CreationalDesignPattern;

namespace dsa.AlgorithmsTests
{
    public class SingletonDesignPatternTests
    {
        private readonly SingletonDesignPattern singletonDesignPattern;
        public SingletonDesignPatternTests()
        {
            singletonDesignPattern = SingletonDesignPattern.GetInstance();
        }

        [Fact]
        public void TestSingletonInstance()
        {
            // Arrange
            SingletonDesignPattern instance1 = SingletonDesignPattern.GetInstance();
            SingletonDesignPattern instance2 = SingletonDesignPattern.GetInstance();
            // Act & Assert
            Assert.Same(instance1, instance2);
        }
    }
}