using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Interface;
using TodoList_WebApp.Models;

namespace TodoList_WebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoInterface _todoInterface;

        public TodoController(ITodoInterface todoInterface)
        {
            _todoInterface = todoInterface;
        }
        
        public IActionResult Index()
        {
            var listTodos = _todoInterface.GetTodos();

            TodoViewModel viewModel = new TodoViewModel()
            {
                todoModels = listTodos
            };

            return View(viewModel);
        }

        public IActionResult AddTodo(TodoModel todo)
        {
            todo.Status = PostStatus.InProgress;
            _todoInterface.AddTodo(todo);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _todoInterface.DeleteTodo(id);

            return RedirectToAction("index");
        }

        public IActionResult Finish(int id)
        {
            TodoModel todo = _todoInterface.GetTodo(id);
            todo.Status = PostStatus.Finished;
            _todoInterface.UpdateTodo(todo);

            return RedirectToAction("index");
        }
    }
}
