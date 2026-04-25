using dsa.Algorithms.design_patterns;
using dsa.csharp.Extensions;
using dsa.problem.statements.blackbaud_coding;
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
        
    }
}
