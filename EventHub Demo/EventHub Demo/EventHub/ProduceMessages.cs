using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Text;

namespace EventHub_Demo.EventHub
{
    public class ProduceMessages<TValue> : IDisposable, IProduceMessages<TValue> where TValue : class
    {
        EventHubProducerClient _producer;
        public ProduceMessages(IConfigurationSection eventHubConfig)
        {
            _producer = new EventHubProducerClient(eventHubConfig["ConnectionString"], eventHubConfig["EventHubName"]);
        }
        public async Task ProduceAsync(TValue value)
        {
            using EventDataBatch eventBatch = await _producer.CreateBatchAsync();

            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event {value}")));

            await _producer.SendAsync(eventBatch);
        }
        public async void Dispose()
        {
            await _producer.DisposeAsync();
        }
    }
}