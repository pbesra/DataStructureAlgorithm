using dsa.core.Core.Interfaces;

namespace dsa.Algorithms.DesignPatterns.CreationalDesignPattern
{
    public class AbstractFactoryPattern : IClient
    {
        private readonly IGUIProductFactory _guiProductFactory;

        public AbstractFactoryPattern(IGUIProductFactory guidProductFactory)
        {
            _guiProductFactory = guidProductFactory;
        }

        public void Execute()
        {
            // Create products using the factory
            var productButton = _guiProductFactory.CreateButton();
            productButton.Render();

            var productCheckbox = _guiProductFactory.CreateCheckbox();
            productCheckbox.Render();
        }
    }

    // Specify Product Interfaces
    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    // Implement Concrete Products

    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows button");
        }
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows checkbox");
        }
    }

    public class MacOSButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering macOS button");
        }
    }

    public class MacOSCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering macOS checkbox");
        }
    }

    // Define Abstract Factory Interface that declares methods for creating abstract product objects

    public interface IGUIProductFactory
    {
        IButton CreateButton();

        ICheckbox CreateCheckbox();
    }

    // Implement Concrete Factories

    public class WindowsFactory : IGUIProductFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    public class MacOSFactory : IGUIProductFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacOSCheckbox();
        }
    }
}