using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your message!");
                var messagePart = Console.ReadLine();
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var message = "Getting started with .Net Core RabbitMQ " + messagePart;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Sent message {message}");
                Console.WriteLine("Press [enter] to exit the Sender");
            }
        }
    }
}
