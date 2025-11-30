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
                Sender.Tell($"Echo: {message}");
                Context.Stop(Self);
            });
        }
    }
}