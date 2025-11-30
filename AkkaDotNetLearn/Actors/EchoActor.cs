using Akka.Actor;

namespace AkkaDotNetLearn.Actors
{
    // A simple actor that echoes received messages to the console
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<string>(message =>
            {
                Console.WriteLine($"EchoActor received: {message}");
                if (Sender != ActorRefs.NoSender && Sender.Path.Name != "deadLetters")
                {
                    Sender.Tell($"Echo: {message}");
                }
            });
        }
    }
}