using Akka.Actor;
using AkkaDotNetLearn.Actors;

namespace AkkaDotNetLearn
{
    public static class ActorSystemExtensions
    {
        public static async Task<IActorRef> RunEchoActorAsync(this ActorSystem system)
        {
            var echo = system.ActorOf(Props.Create(() => new EchoActor()), "echo");

            echo.Tell("Hello Akka.NET");
            echo.Tell("This is a sample application");

            var responseMessage = await echo.Ask<string>("Hello");
            Console.WriteLine(responseMessage);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            return echo;
        }
    }
}