using dsa.csharp.Extensions;
using dsa.interview.preparation.garbage_example;
using Microsoft.Extensions.DependencyInjection;

namespace dsa.csharp;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.ConfigureServices();

        InterviewPreparation();


    }

    public static void InterviewPreparation()
    {
        Animal animal = new Tiger();
        animal.Speak();
    }
}
