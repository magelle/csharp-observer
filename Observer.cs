using System.Collections.Generic;
using Todo;

namespace Observer {
    public interface IObserver
    {
        public void Notify(List<Task> todos);
    }

    public interface ISubject {
        public void AddObserver(IObserver printer);
        public void RemoveObserver(IObserver printer);
        public void NotifyObservers();
    }
}