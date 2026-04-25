namespace dsa.Algorithms.design_patterns;

public class SingletonPattern
{
    private static SingletonPattern? _instance = new SingletonPattern();
    private SingletonPattern()
    {
        
    }

    public static SingletonPattern? GetInstance()
    {
        return _instance;
    }
}