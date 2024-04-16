using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    string? name = "Bebra";
    int? price = 228;
    while (true) {
        Console.Write("Name of Tournament: ");
        name = Console.ReadLine();
        Console.Write("Price to enter: ");
        price = Convert.ToInt32(Console.ReadLine());
        if (name == null || price == null)
        {
            break;
        }
        var responce = await producer.ProduceAsync("tournament-topic", new Message<Null, string> { Value = JsonConvert.SerializeObject(new Tournament(name, price.Value))});
        Console.WriteLine(responce.Value);
    }
}
catch (ProduceException<Null, string> ex)
{
    Console.WriteLine(ex.Message);
}
public record Tournament(string Name, int Price);