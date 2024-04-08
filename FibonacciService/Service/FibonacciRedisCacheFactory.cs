namespace FibonacciService.Service;

public class FibonacciRedisCacheFactory
{
    public static FibonacciRedisCache Create()
    {
        return new FibonacciRedisCache("redis", 6379, "");
    }
}