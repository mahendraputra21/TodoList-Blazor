namespace TodoList.Client.Features.TodoLists.Models
{
    public class TodoState
    {
        public TodoResponse? TodoData { get; set; }
        public HashSet<TodoModel> SelectedTodos { get; set; } = [];
    }
}
