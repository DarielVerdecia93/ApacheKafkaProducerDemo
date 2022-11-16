
namespace ApacheKafkaProducerDemo.Models
{
    public class MessageKafka_DllMover
    {
        public Data Before { get; set; }

        public Data After { get; set; }

        public string Entity { get; set; }

        public string State { get; set; }

        public long IdGame { get; set; }

        public int IdLineType { get; set; }
    }
}