using dsa.Algorithms.RateLimiters;
using System.Diagnostics;
using System.Threading.Tasks;

namespace dsa.AlgorithmsTests
{
    public class TokenBucketRateLimiterTests
    {
        private readonly TokenBucketRateLimiter _rateLimiter;
        public TokenBucketRateLimiterTests()
        {
            _rateLimiter = new TokenBucketRateLimiter();
        }

        [Fact]
        public async Task TestProcessRequest_SimulationAsync()
        {
            // Configure limiter for the simulation
            var limiter = new TokenBucketRateLimiter
            {
                Capacity = 10,
                RefillRatePerSecond = 2,
                LastRefillTime = DateTime.Now,
                CurrentTokens = 10
            };

            var sw = Stopwatch.StartNew();

            // Steady stream: one request every 100ms for ~6 seconds
            var steady = Task.Run(async () =>
            {
                int i = 0;
                while (sw.Elapsed.TotalSeconds < 6)
                {
                    bool accepted = limiter.ProcessRequest();
                    Console.WriteLine($"[{sw.Elapsed.TotalSeconds:F2}s] Steady #{i++}: accepted={accepted}, tokens={limiter.CurrentTokens:F2}");
                    await Task.Delay(200);
                }
            });

            // Burst after 2 seconds: rapid-fire requests
            var burst = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                Console.WriteLine($"\n--- Burst at {sw.Elapsed.TotalSeconds:F2}s: sending 20 rapid requests ---");
                for (int j = 0; j < 20; j++)
                {
                    bool accepted = limiter.ProcessRequest();
                    Console.WriteLine($"[{sw.Elapsed.TotalSeconds:F2}s] Burst #{j}: accepted={accepted}, tokens={limiter.CurrentTokens:F2}");
                }
                Console.WriteLine("--- End burst ---\n");
            });

            await Task.WhenAll(steady, burst);
            sw.Stop();

            Console.WriteLine($"Simulation finished. Final tokens={limiter.CurrentTokens:F2}");
        }
    }
}
