using System;
using Akka.Actor;

namespace AkkaDotNetLearn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create the actor system
            using var system = ActorSystem.Create("MyActorSystem");

            // Create an EchoActor
            var echo = system.ActorOf(Props.Create(() => new EchoActor()), "echo");

            // Send messages
            echo.Tell("Hello Akka.NET");
            echo.Tell("This is a sample application");

            // Wait for user input before shutting down
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            // Terminate the actor system
            system.Terminate().Wait();
        }
    }

    // A simple actor that echoes received messages to the console
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<string>(message =>
            {
                Console.WriteLine($"EchoActor received: {message}");
                Sender.Tell($"Echo: {message}");
            });
        }
    }
}