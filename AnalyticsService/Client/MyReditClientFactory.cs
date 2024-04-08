namespace AnalyticsService.Client;

public class MyReditClientFactory
{
    public static MyRedisClient CreateClient()
    {
        return new MyRedisClient("redis", 6379, "");
    }
}