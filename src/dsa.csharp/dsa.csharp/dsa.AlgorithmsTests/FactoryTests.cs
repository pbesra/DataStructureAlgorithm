using dsa.Algorithms.design_patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.AlgorithmsTests
{
    public class FactoryTests
    {
        private readonly Client _client;
        public FactoryTests()
        {
            _client = new Client();
        }

        [Fact]
        public void TestPayPalPayment()
        {
            _client.MakePayment("PayPal", 1000m);
        }
    }
}
