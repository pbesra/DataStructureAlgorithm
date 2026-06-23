namespace dsa.Algorithms.RateLimiters
{
    public class TokenBucketRateLimiter
    {
        public int Capacity { get; set; }
        public double RefillRatePerSecond { get; set; }
        public DateTime LastRefillTime { get; set; }
        public double CurrentTokens { get; set; }

        public TokenBucketRateLimiter()
        {
            Capacity = 100;
            RefillRatePerSecond = 5;
            LastRefillTime = DateTime.Now;
            CurrentTokens = Capacity;
        }

        public bool ProcessRequest()
        {
            var elapsedTime = DateTime.Now - LastRefillTime;
            var tokensToAdd = elapsedTime.TotalSeconds * RefillRatePerSecond;
            CurrentTokens = Math.Min(Capacity, CurrentTokens + tokensToAdd);
            LastRefillTime = DateTime.Now;

            if (CurrentTokens >= 1)
            {
                CurrentTokens--;
                return true;
            }
            return false;
        }
    }
}