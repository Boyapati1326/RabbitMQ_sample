using System.Text;
using RabbitMQ.Client;
using Send;

namespace Send
{
    public class Send : ITest
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Hi I am a RabbitMQ Sender");
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            for (int i = 0; i <= 5; i++)
            {
                channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

                string message = Console.ReadLine();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($" [x] Sent {message}");
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            Console.WriteLine(Testing());
            Console.ReadKey();



        }

        public static string Testing()
        {
            string val = string.Empty;
            int[] a = new int[3];
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    a[i] = i;
                }
                return "I am done";
            }
            catch (Exception ex)
            {
                Console.WriteLine("I am exception");
                return "I am exception";
            }
            finally
            {
                Console.WriteLine("i am finally");
                val = "i am finally";
            }
            return val;
        }
    }
}