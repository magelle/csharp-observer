using System;
using Todo;
using TodosPrinter;
using System.Collections.Generic;
using Observer;
using TodoRepository;

namespace observer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Observer.IObserver<List<Task>>> printers = new List<Observer.IObserver<List<Task>>>();
            Todos todos = new Todos(new InMemoryTodoRepository());
            todos.AddObserver(new StatsPrinter());
            todos.AddObserver(new YetToDoPrinter());
            todos.AddObserver(new AllTaskPrinter());
            while (true)
            {
                string action = SelectAction();
                ExecuteAction(todos, action);
            }
        }

        static string SelectAction()
        {
            Console.WriteLine("\nWhat do you what to do? ");
            Console.WriteLine("\nadd, toggle, clean? ");
            return Console.ReadLine();
        }
        static void ExecuteAction(Todos todos, string action)
        {
            switch (action)
            {
                case "add": 
                    Console.WriteLine("\nName the task to add :");
                    todos.AddTodo(Console.ReadLine()); 
                    break;
                case "toggle": 
                    Console.WriteLine("\nName the task to toggle :");
                    todos.ToggleDone(Console.ReadLine()); 
                    break;
                case "clean":
                    todos.RemoveDones(); 
                    break;
                default:
                    Console.WriteLine($"Unknown command :/");
                    break;
            }
        }
    }
}
