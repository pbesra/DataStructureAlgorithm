namespace dsa.core.Core.Corebase
{
    public class SizeTracker
    {
        public int Size { get; set; } = 0;
        public void IncrementLength(int n = 1)
        {
            Size += n;
        }
        public void DecrementLength(int n = 1)
        {
            Size -= n;
        }

    }
}