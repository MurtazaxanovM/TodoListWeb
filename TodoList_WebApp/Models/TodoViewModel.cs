using System.Collections.Generic;
using TodoList.Domain;

namespace TodoList_WebApp.Models
{
    public class TodoViewModel
    {
        public List<TodoModel> todoModels { get; set; }
        public TodoModel Todo { get; set; }
    }
}
