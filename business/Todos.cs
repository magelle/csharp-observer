using System.Collections.Generic;
using System;
using Observer;

namespace Todo
{

    public class Todos: ISubject
    {
        private ITodoRepository _repository;
        private List<IObserver> _observers = new List<IObserver>();

        public Todos(ITodoRepository repository) {
            _repository = repository;
        }

        public void AddObserver(IObserver printer)
        {
            _observers.Add(printer);
        }

        public void RemoveObserver(IObserver printer)
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
            foreach(IObserver observer in _observers)
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