namespace Soccer.Notifications.Abstractions
{
    public interface INotifier
    {
        void Notify(string subject, string message, params string[] destination);
    }
}
