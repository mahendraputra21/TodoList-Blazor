﻿using System.Text.Json.Serialization;

namespace TodoList.Server.Features.TodoLists.Models
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string? Todo { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
