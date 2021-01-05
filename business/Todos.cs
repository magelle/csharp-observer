using System.Collections.Generic;
using System;
using Observer;

namespace Todo
{

    public class Todos: Observer.ISubject<List<Task>>
    {
        private ITodoRepository _repository;
        private List<Observer.IObserver<List<Task>>> _observers = new List<Observer.IObserver<List<Task>>>();

        public Todos(ITodoRepository repository) {
            _repository = repository;
        }

        public void AddObserver(Observer.IObserver<List<Task>> printer)
        {
            _observers.Add(printer);
        }

        public void RemoveObserver(Observer.IObserver<List<Task>> printer)
        {
            _observers.Remove(printer);
        }

        public void AddTodo(string name)
        {
            _repository.Add(new Task() { Name = name, Done = false });
            NotifyObservers();
        }

        public void ToggleDone(string name)
        {
            foreach (Task aTodo in _repository.FindAll())
            {
                if (aTodo.Name.Equals(name))
                {
                    aTodo.Done = !aTodo.Done;
                    _repository.Update(aTodo);
                }
            }
            NotifyObservers();
        }

        public void RemoveDones()
        {
            foreach (Task aTodo in _repository.FindAll())
            {
                if (IsDone(aTodo))
                {
                    _repository.Remove(aTodo);
                }
            }
            NotifyObservers();
        }

        private static bool IsDone(Task task)
        {
            return task.Done;
        }

        public void NotifyObservers()
        {
            List<Task> tasks = _repository.FindAll();
            foreach(Observer.IObserver<List<Task>> observer in _observers)
            {
                observer.Notify(tasks);
                Console.WriteLine($"\n----------------------------------------------------------");
            }
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}