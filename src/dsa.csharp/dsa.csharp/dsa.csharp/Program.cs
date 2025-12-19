using dsa.csharp.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace dsa.csharp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, DSA in C#!");
        var services = new ServiceCollection();
        services.ConfigureServices();
    }
}
