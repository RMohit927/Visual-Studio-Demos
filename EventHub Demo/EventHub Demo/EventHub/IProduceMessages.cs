namespace EventHub_Demo.EventHub
{
    public interface IProduceMessages<in TValue> where TValue : class
    {
        Task ProduceAsync(TValue value);
    }
}