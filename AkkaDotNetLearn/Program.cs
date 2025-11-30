using Akka.Actor;

namespace AkkaDotNetLearn
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var system = ActorSystem.Create("MyActorSystem");

            var echo = await system
                .RunEchoActorAsync();

            // request graceful shutdown
            bool success = await echo.GracefulStop(TimeSpan.FromSeconds(3));
            Console.WriteLine($"Actor stopped = {success}");

            await system.Terminate();
        }
    }
}