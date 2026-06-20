namespace dsa.Algorithms.RateLimiters
{
    public class FixedWindowRateLimiter
    {
        public int RequestCount { get; private set; }
        public int MaxRequests { get; private set; }
        public int WindowSizeInSeconds { get; private set; }
        public DateTime WindowStart { get; private set; }

        public FixedWindowRateLimiter()
        {
            MaxRequests = 5;
            WindowSizeInSeconds = 10;
            WindowStart= DateTime.Now;
        }

        public void UpdateWindow()
        {
            var currentTime = DateTime.Now;
            var timeElapsed = (currentTime - WindowStart).TotalSeconds;
            if (timeElapsed > WindowSizeInSeconds)
            {
                RequestCount = 0;
                // Reset the window start time to the current time minus the remainder of the elapsed time
                // Because we want to start a new window that is aligned with the current time, we subtract the remainder of the elapsed time from the current time.
                // timeElapsed % WindowSizeInSeconds means divide the elapsed time by the window size and take the remainder. This gives us the amount of time that has passed since the last full window.
                WindowStart = currentTime.AddSeconds(timeElapsed % WindowSizeInSeconds);
            }
        }
        public bool ProcessRequest()
        {
            UpdateWindow();
            if (RequestCount>=MaxRequests)
            {
                return false;
            }

            RequestCount++;
            return true;
        }
    }
}