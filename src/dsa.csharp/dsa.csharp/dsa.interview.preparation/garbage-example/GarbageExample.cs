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

public abstract class Payment
{
    public abstract void Pay();
    public abstract void Cancel();
    public abstract void Refund();
    public abstract void Chargeback();
    public void HasPayment()
    {
        Console.WriteLine("Has payment");
    }
}

public class RazorPay : Payment
{
    public override void Pay()
    {
        Console.WriteLine("RazorPay pay");
    }

    public override void Cancel()
    {
        throw new NotImplementedException();
    }

    public override void Refund()
    {
        throw new NotImplementedException();
    }

    public override void Chargeback()
    {
        throw new NotImplementedException();
    }
}

public class Earth
{
    public delegate void GetArea(int radius);
}

public class Area
{
    public void CalculateArea(int radius)
    {
        Console.WriteLine(2*Math.PI*radius);
    }

    public void CalculateVolume(Func<double, double, double, double> func)
    {
        var volume = func(1,2,3);
        Console.WriteLine(volume);
    }
}

