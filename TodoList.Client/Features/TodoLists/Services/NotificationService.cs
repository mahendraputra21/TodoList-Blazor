using BlazorBootstrap;
using TodoList.Client.Features.TodoLists.Interfaces;

namespace TodoList.Client.Features.TodoLists.Services
{
    public class NotificationService : INotificationService
    {
        public event Action? OnChange;
        public List<ToastMessage> Messages { get; } = new();

        public void AddToastMessage(ToastType level, string message)
        {
            Messages.Add(new ToastMessage
            {
                Type = level,
                Message = message
            });
            OnChange?.Invoke();
        }
    }
}
