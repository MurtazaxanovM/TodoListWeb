using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Data;
using TodoList.Domain;
using TodoList.Interface;

namespace TodoList.Repos
{
    public class TodoListRepo : ITodoInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoListRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TodoModel AddTodo(TodoModel newTodo)
        {
            _dbContext.TodoList.Add(newTodo);
            _dbContext.SaveChanges();

            return newTodo;
        }

        public bool DeleteTodo(int id)
        {
            try
            {
                var todo = _dbContext.TodoList.FirstOrDefault(t => t.Id == id);
                _dbContext.Remove(todo);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TodoModel GetTodo(int id)
        {
            return _dbContext.TodoList.FirstOrDefault(t => t.Id == id);
        }

        public List<TodoModel> GetTodos()
        {
            return _dbContext.TodoList.ToList();
        }

        public TodoModel UpdateTodo(TodoModel newTodo)
        {
            _dbContext.TodoList.Update(newTodo);
            _dbContext.SaveChanges();

            return newTodo;
        }
    }
}
