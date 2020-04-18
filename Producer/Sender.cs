using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main()
        {
            for (var i = 0; i < 10000 ; i++)
            {
                const string queueName = "LearnBasicQueue";
                Console.WriteLine("Enter your message!");
                var messagePart = $"---------- {i}"; //Console.ReadLine();
                var factory = new ConnectionFactory {HostName = "localhost"};
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(queueName, false, false, false, null);
                var message = "Getting started with .Net Core RabbitMQ " + messagePart;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", queueName, null, body);
                Console.WriteLine($"Sent message {message}");
                //Console.WriteLine("Press [enter] to exit the Sender");
            }
        }
    }
}
