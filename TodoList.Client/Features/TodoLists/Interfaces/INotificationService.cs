using BlazorBootstrap;

namespace TodoList.Client.Features.TodoLists.Interfaces
{
    public interface INotificationService
    {
        void AddToastMessage(ToastType level, string message);
    }
}
