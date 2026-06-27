namespace dsa.Algorithms.SolidDesignPatterns
{
    public interface IFlyable
    {
        void Fly();
    }

    public abstract class Bird
    {
    }

    public class Penguin : Bird
    {
    }

    public class SingleResponsibility
    {
        public SingleResponsibility()
        {
            Bird sparrow = new Sparrow();

            Bird penguin = new Penguin();
        }
    }
    public class Sparrow : Bird, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}