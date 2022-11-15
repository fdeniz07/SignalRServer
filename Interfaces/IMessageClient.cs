namespace SignalRServer.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);

        Task UserJoined(string connectionId);

        Task UserLeaved(string connectiondId);
    }
}
