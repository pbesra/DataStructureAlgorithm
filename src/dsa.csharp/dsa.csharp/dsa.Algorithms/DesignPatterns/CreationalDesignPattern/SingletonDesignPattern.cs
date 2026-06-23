using dsa.core.Core.Interfaces;

namespace dsa.Algorithms.DesignPatterns.CreationalDesignPattern
{
    public class SingletonDesignPattern
    {
        private static SingletonDesignPattern _instance = new SingletonDesignPattern();

        private SingletonDesignPattern()
        { }

        public static SingletonDesignPattern GetInstance()
        {
            return _instance;
        }
    }

    public class Client : IClient
    {
        public void Execute()
        {
            SingletonDesignPattern singleton1 = SingletonDesignPattern.GetInstance();
            SingletonDesignPattern singleton2 = SingletonDesignPattern.GetInstance();
            if (singleton1 == singleton2)
            {
                Console.WriteLine("Both instances are the same.");
            }
            else
            {
                Console.WriteLine("Instances are different.");
            }
        }
    }
}