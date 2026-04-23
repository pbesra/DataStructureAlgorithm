namespace dsa.interview.preparation.garbage_example;

public class GarbageExample : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this); // 🔥 important
    }

    public void PrintObject()
    {
        Console.WriteLine("called PrintObject");
    }
    
    
}

public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}

public class Tiger: Animal
{
    public override void Speak()
    {
        Console.WriteLine("Tiger speaks");
    }
}