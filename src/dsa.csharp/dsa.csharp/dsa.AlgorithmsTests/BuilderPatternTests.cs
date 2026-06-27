using dsa.Algorithms.DesignPatterns.CreationalDesignPattern;

namespace dsa.AlgorithmsTests
{
    public class BuilderPatternTests
    {
        public BuilderPatternTests()
        {
        }

        [Fact]
        public void TestBuilderPattern()
        {
            HouseDirector houseDirector = new HouseDirector();
            House house = houseDirector.ConstructLuxuryHouse(new ConcreteHouseBuilder());

            Assert.True(house != null);
            Assert.True(house.HasWalls);
            Assert.True(house.HasGarage);
            Assert.True(house.HasPool);
        }

        [Fact]
        public void GetResult_CalledTwiceOnSameBuilder_ReturnsDistinctInstances()
        {
            var director = new HouseDirector();
            var builder = new ConcreteHouseBuilder();

            House first = director.ConstructMinimalHouse(builder);
            House second = director.ConstructLuxuryHouse(builder);

            Assert.NotSame(first, second);
        }
    }
}