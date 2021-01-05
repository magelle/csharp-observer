using System.Collections.Generic;
using Todo;

namespace Observer {
    public interface IObserver<T>
    {
        public void Notify(T evt);
    }

    public interface ISubject<S> {
        public void AddObserver(IObserver<S> observer);
        public void RemoveObserver(IObserver<S> observer);
        public void NotifyObservers();
    }
}