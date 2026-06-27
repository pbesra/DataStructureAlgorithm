using dsa.core.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.Algorithms.DesignPatterns.CreationalDesignPattern
{
    public class BuilderPattern : IClient
    {
        private readonly HouseDirector _houseDirector;

        public BuilderPattern()
        {
            _houseDirector = new HouseDirector();
        }

        public void Execute()
        {
            _houseDirector.ConstructLuxuryHouse(new ConcreteHouseBuilder());
            _houseDirector.ConstructMinimalHouse(new ConcreteHouseBuilder());
        }
    }

    public interface IHouseBuilder
    {
        IHouseBuilder BuildWalls();

        IHouseBuilder BuildRoof();

        IHouseBuilder BuildGarage();

        IHouseBuilder BuildPool();

        House GetResult();
    }

    public class House
    {
        public bool HasWalls { get; set; }
        public bool HasRoof { get; set; }
        public bool HasGarage { get; set; }
        public bool HasPool { get; set; }

        public override string ToString() =>
            $"House [Walls={HasWalls}, Roof={HasRoof}, Garage={HasGarage}, Pool={HasPool}]";
    }

    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house;

        public ConcreteHouseBuilder()
        {
            _house = new House();
        }

        public IHouseBuilder BuildWalls()
        { _house.HasWalls = true; return this; }

        public IHouseBuilder BuildRoof()
        { _house.HasRoof = true; return this; }

        public IHouseBuilder BuildGarage()
        { _house.HasGarage = true; return this; }

        public IHouseBuilder BuildPool()
        { _house.HasPool = true; return this; }

        public House GetResult()
        {
            var result = _house;
            // reset the builder for the next build
            Reset();
            return result;
        }

        private void Reset()
        {
            _house = new House();
        }
    }

    public class HouseDirector
    {
        public House ConstructMinimalHouse(IHouseBuilder builder) =>
            builder.BuildWalls().BuildRoof().GetResult();

        public House ConstructLuxuryHouse(IHouseBuilder builder) =>
            builder.BuildWalls().BuildRoof().BuildGarage().BuildPool().GetResult();
    }
}