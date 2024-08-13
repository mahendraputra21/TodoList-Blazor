using BlazorBootstrap;
using TodoList.Client.Interfaces;

namespace TodoList.Client.Services
{
    public class NotificationService : INotificationService
    {
        public event Action? OnChange;
        public List<ToastMessage> Messages { get; } = new();

        public void AddToastMessage(ToastType level, string title, string message)
        {
            Messages.Add(new ToastMessage
            {
                Type = level,
                Title = title,
                Message = message
            });
            OnChange?.Invoke();
        }
    }
}
