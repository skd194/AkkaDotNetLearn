using Akka.Actor;
using Akka.Event;

namespace AkkaDotNetLearn.Actors
{
    public class IotSupervisor : ReceiveActor
    {
        public ILoggingAdapter _loggingAdapter = Context.GetLogger();

        public IotSupervisor()
        {
            Receive<string>(message =>
            {
                _loggingAdapter.Info($"IotActor received: {message}");
                if (Sender != ActorRefs.NoSender && Sender.Path.Name != "deadLetters")
                {
                    Sender.Tell($"IotActor Echo: {message}");
                }
            });
        }

        protected override void PreStart()
        {
            _loggingAdapter.Info("IotActor PreStart");
        }

        protected override void PostStop()
        {
            _loggingAdapter.Info("IotActor PostStop");
        }
    }
}