using dsa.Algorithms.DesignPatterns.CreationalDesignPattern;
using Moq;

namespace dsa.AlgorithmsTests
{
    public class AbstractFactoryPatternTests
    {
        
        public AbstractFactoryPatternTests()
        {
           
        }

        [Fact]
        public void TestAbstractFactoryPattern()
        {
            // Create a Windows GUI product factory
            IGUIProductFactory windowsFactory = new WindowsFactory();
            AbstractFactoryPattern windowsApp = new AbstractFactoryPattern(windowsFactory);
            windowsApp.Execute();

            // Create a macOS GUI product factory
            IGUIProductFactory macFactory = new MacOSFactory();
            AbstractFactoryPattern macApp = new AbstractFactoryPattern(macFactory);
            macApp.Execute();
        }

        [Fact]
        public void Execute_CallsRender_OnCreatedButtonAndCheckbox()
        {
            // Arrange
            var mockFactory = new Mock<IGUIProductFactory>();
            var mockButton = new Mock<IButton>();
            var mockCheckbox = new Mock<ICheckbox>();

            mockFactory.Setup(f => f.CreateButton()).Returns(mockButton.Object);
            mockFactory.Setup(f => f.CreateCheckbox()).Returns(mockCheckbox.Object);

            var app = new AbstractFactoryPattern(mockFactory.Object);

            // Act
            app.Execute();

            // Assert — Render() was called on whatever the factory handed back
            mockButton.Verify(b => b.Render(), Times.Once);
            mockCheckbox.Verify(c => c.Render(), Times.Once);
        }
    }
}