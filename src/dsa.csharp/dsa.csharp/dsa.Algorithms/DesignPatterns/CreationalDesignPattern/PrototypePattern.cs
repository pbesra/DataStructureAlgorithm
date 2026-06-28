using dsa.core.Core.Interfaces;

namespace dsa.Algorithms.DesignPatterns.CreationalDesignPattern
{
    public class PrototypePattern : IClient
    {
        public PrototypePattern()
        {
            var original = new Circle(10, "Red");
            var copy = original.Clone();
            Console.WriteLine($"origial: {original}, copy: {copy}");
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public interface IShape
    {
        IShape Clone();

        void Draw();
    }

    public class Circle : IShape
    {
        public int Radius { get; set; }
        public string Color { get; set; }

        public Circle(int radius, string color)
        {
            Radius = radius;
            Color = color;
        }

        // Copy constructor backs the clone
        private Circle(Circle source)
        {
            Radius = source.Radius;
            Color = source.Color;
        }

        public IShape Clone()
        {
            return new Circle(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Circle: Radius: {Radius}, Color: {Color}");
        }
    }
}