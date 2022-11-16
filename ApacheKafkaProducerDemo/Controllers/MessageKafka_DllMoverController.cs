using Microsoft.AspNetCore.Mvc;

using Confluent.Kafka;
using System.Net;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using ApacheKafkaProducerDemo.Models;

namespace ApacheKafkaProducerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageKafka_DllMoverController : ControllerBase
    {
        private readonly string
        bootstrapServers = "localhost:29092";
        private readonly string topic = "consumer.agent.changes";

        [HttpPost]
        public async Task<IActionResult>
        Post([FromBody] MessageKafka_DllMover data)
        {
            string message = JsonSerializer.Serialize(data);
            return Ok(await SendOrderRequest(topic, message));
        }
        private async Task<bool> SendOrderRequest
        (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });

                    Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");

                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }
    }
}

