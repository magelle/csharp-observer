using System.Collections.Generic;

namespace Todo {
    public interface ITodoRepository {
        void Add(Task todo);
        void Remove(Task todo);
        void Update(Task todo);
        Task FindByName(string name);
        List<Task> FindAll();
    }
}