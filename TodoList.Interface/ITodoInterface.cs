using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Interface
{
    public interface ITodoInterface
    {
        List<TodoModel> GetTodos();
        TodoModel GetTodo(int id);
        TodoModel AddTodo(TodoModel newTodo);
        TodoModel UpdateTodo(TodoModel newTodo);
        bool DeleteTodo(int id);
    }
}
