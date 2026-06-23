namespace dsa.Algorithms.design_patterns;

public class Factory
{
    
}

public class Client
{
    public void MakePayment(string processorType, decimal amount)
    {
        IPaymentProcessor paymentProcessor = PaymentProcessorFactory.CreatePaymentProcessor(processorType);
        paymentProcessor.ProcessPayment(amount);
    }
}

class PaymentProcessorFactory
{
    public static IPaymentProcessor CreatePaymentProcessor(string type)
    {
        return type switch
        {
            "PayPal" => new PayPalPaymentProcessor(),
            "Stripe" => new StripePaymentProcessor(),
            "JPMorgan" => new JPMorganPaymentProcessor(),
            _ => throw new ArgumentException("Invalid payment processor type")
        };
    }
}

class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} through PayPal.");
    }
}

class StripePaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} through Stripe.");
    }
}

class JPMorganPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} through JPMorgan.");
    }
}

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}