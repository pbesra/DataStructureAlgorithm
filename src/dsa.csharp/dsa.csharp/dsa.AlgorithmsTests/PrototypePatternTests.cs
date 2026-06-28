using dsa.Algorithms.DesignPatterns.CreationalDesignPattern;

namespace dsa.AlgorithmsTests
{
    public class PrototypePatternTests
    {
        public PrototypePatternTests()
        {
        }

        [Fact]
        public void TestPrototypePattern()
        {
            var original = new Circle(10, "Red");
            var copy = original.Clone();

            Assert.NotSame(original, copy);
            Assert.Equal(original.Radius, ((Circle)copy).Radius);
            Assert.Equal(original.Color, ((Circle)copy).Color);
        }
    }
}