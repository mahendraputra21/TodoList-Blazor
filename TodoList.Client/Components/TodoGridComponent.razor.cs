using BlazorBootstrap;
using TodoList.Client.Interfaces;
using TodoList.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace TodoList.Client.Components
{
    public partial class TodoGridComponent : ComponentBase
    {
        // Inject services
        [Inject] private ITodoDataProvider TodoDataProvider1 { get; set; } = null!;
        [Inject] private ITodoSearchService TodoSearchService { get; set; } = null!;
        [Inject] private INotificationService NotificationService { get; set; } = null!;

        private TodoState State { get; set; } = new TodoState();
        private List<TodoModel> AllTodos { get; set; } = [];
        private string SearchTerm { get; set; } = string.Empty;
        private Guid GridKey { get; set; } = Guid.NewGuid();

        private ConfirmDialog dialog = default!;


        protected override async Task OnInitializedAsync()
        {
            await FetchTodoData();
        }

        private async Task FetchTodoData()
        {
            State.TodoData = null; // Show loading spnner if used in the UI
            AllTodos.Clear();
            int skip = 0;
            int pageSize = 0; // Adjust based on your API's capabilities
            bool hasMoreData = true;

            while (hasMoreData) 
            { 
                var response = await TodoDataProvider1.GetTodosAsync(pageSize, skip);
                if (!response.Any())
                {
                    hasMoreData = false;
                }

                AllTodos.AddRange(response);
                skip += pageSize; // Increase skip by the actual number of items received
                hasMoreData = response.Count() == pageSize; // If we received fewer items than requested, we've reached the end
            }

            State.TodoData = new TodoResponse
            {
                Todos = AllTodos.OrderBy(x => x.Todo).ToList(),
                Total = await TodoDataProvider1.GetTotalCountAsync()
            };
        }
        private void HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                HandleTodoGridSearch();
            }
        }
        private void HandleTodoGridSearch()
        {
            var filteredTodos = TodoSearchService.SearchTodos(AllTodos, SearchTerm).ToList();

            State.TodoData = new TodoResponse
            {
                Todos = filteredTodos.OrderBy(x => x.Todo).ToList(),
                Total = filteredTodos.Count
            };

            GridKey = Guid.NewGuid();
            StateHasChanged();
        }
        private async Task<GridDataProviderResult<TodoModel>> TodoDataProvider(GridDataProviderRequest<TodoModel> request)
        {
            if(State.TodoData == null)
            {
                return new GridDataProviderResult<TodoModel>
                {
                    Data = new List<TodoModel>(),
                    TotalCount = 0
                };
            }

            int pageSize = request.PageSize;
            int skip = (request.PageNumber - 1) * pageSize;
            var pagedData = State.TodoData.Todos.Skip(skip).Take(pageSize).ToList();

            return new GridDataProviderResult<TodoModel>
            {
                Data = pagedData,
                TotalCount = State.TodoData.Total            
            };
        }

        private async Task ShowConfirmationAsync(int id)
        {
            var confirmation = await dialog.ShowAsync(
                title: $"Are you sure?",
                message1: "This will delete the record. Once deleted can not be rolled back.",
                message2: "Do you want to proceed?");

            if (confirmation)
            {
                try
                {
                    // do something
                    await TodoDataProvider1.DeleteTodoByIdAsync(id);

                    // show Toast auto hide
                    NotificationService.AddToastMessage(
                        ToastType.Success,
                        "Delete Successful",
                        $"Todo with ID {id} has been successfully deleted."
                        );

                    await FetchTodoData(); // Refresh the data after deletion
                }
                catch (Exception ex) 
                {
                    // Show error toast if deletion fails
                    NotificationService.AddToastMessage(
                        ToastType.Danger,
                        "Delete Failed",
                        $"Failed to delete Todo with ID {id}. Error: {ex.Message}"
                        );
                }
               
            }
        }
    }
}
