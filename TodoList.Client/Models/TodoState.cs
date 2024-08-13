namespace TodoList.Client.Models
{
    public class TodoState
    {
        public TodoResponse? TodoData { get; set; }
        public HashSet<TodoModel> SelectedTodos { get; set; } = [];
    }
}
