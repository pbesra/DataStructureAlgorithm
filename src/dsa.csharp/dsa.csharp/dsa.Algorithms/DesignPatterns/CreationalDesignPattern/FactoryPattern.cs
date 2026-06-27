using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.Algorithms.DesignPatterns.CreationalDesignPattern
{
    public class FactoryPattern
    {
        public FactoryPattern(string payementProcessor)
        {
            
        }
    }
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }

    public class StripePaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Stripe payment of {amount:C}");
        }
    }

    public class JustPayPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing JustPay payment of {amount:C}");
        }
    }
}


