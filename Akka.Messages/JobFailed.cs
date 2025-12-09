namespace Akka.Messages
{
    public sealed record JobFailed(string JobId, Exception Exception);
}
