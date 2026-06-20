using dsa.Algorithms.RateLimiters;

namespace dsa.AlgorithmsTests
{
    public class FixedWindowRateLimiterTests
    {
        private readonly FixedWindowRateLimiter _rateLimiter;

        public FixedWindowRateLimiterTests()
        {
            _rateLimiter = new FixedWindowRateLimiter();
        }

        [Fact]
        public void TestProcessRequest()
        {
            int processedCount = 0;
            Random random = new Random();
            for (int i = 0; i < 500; i++)
            {
                var result = _rateLimiter.ProcessRequest();
                if (result)
                {
                    Console.WriteLine($"{i} processed");
                    processedCount++;
                }
                else
                {
                    Console.WriteLine($"{i} not processed");
                }

                var val = random.Next();
                Console.WriteLine($"Random val {val}");
                if (val % 2 == 0)
                {
                    Console.WriteLine($"Sleep started -- {val}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Sleep ended -- {val}");
                }
            }

            Console.WriteLine($"Total processed: {processedCount}");
        }
    }
}