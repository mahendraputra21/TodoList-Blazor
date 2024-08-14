﻿namespace TodoList.Server.TodoList.Models
{
    public class TodoResponse
    {
        public List<TodoDto> Todos { get; set; } = [];
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
