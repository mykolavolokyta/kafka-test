using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ConsumerConfig
{
    GroupId = "tournament-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("tournament-topic");

CancellationTokenSource token = new();

try
{
    while (true)
    {
        var responce = consumer.Consume(token.Token);
        if (responce.Message != null)
        {
            var tournament = JsonConvert.DeserializeObject<Tournament>(responce.Message.Value);
            Console.WriteLine($"Hello, Mister Bebra!\nNew tournament has been created!\nName: {tournament.Name}, Price: {tournament.Price}\nAre you in?\n\n");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

public record Tournament(string Name, int Price);