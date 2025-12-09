using Akka.Actor;
using AkkaDotNetLearn.Actors;

namespace AkkaDotNetLearn
{
    public static class ActorSystemExtensions
    {
        public static async Task<IActorRef> RunEchoActorAsync(this ActorSystem system)
        {
            var echoActorRef = system.ActorOf(Props.Create(() => new EchoActor()), "echo");

            echoActorRef.Tell("Hello Akka.NET");
            echoActorRef.Tell("This is a sample application");

            var responseMessage = await echoActorRef.Ask<string>("Hello");
            Console.WriteLine(responseMessage);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            return echoActorRef;
        }

        public static async Task<IActorRef> RunIotSupervisorAsync(this ActorSystem system)
        {
            var supervisor = system.ActorOf(Props.Create(() => new IotSupervisor()), "iot-supervisor-actor");

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            return supervisor;
        }
    }
}