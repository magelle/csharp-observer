using Todo;
using System.Collections.Generic;
using System.Linq;

namespace TodoRepository
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        List<Task> tasks = new List<Task>();
        public void Add(Task todo)
        {
            tasks.Add(todo);
        }
        public void Remove(Task todo)
        {
            tasks.Remove(todo);
        }
        public void Update(Task todo)
        {
            tasks.First(t => t.Name.Equals(todo.Name)).Done = todo.Done;
        }
        public Task FindByName(string name)
        {
            foreach(Task task in tasks)
            {
                if (task.Name.Equals(name))
                {
                    return task;
                }
            }
            return null;
        }
        public List<Task> FindAll()
        {
            /*
            List<Task> t = new List<Task>();
            foreach(Task task in tasks)
            {
                t.Add(task);
            }
            return t;
            */
            return tasks.Select(x => x).ToList();
        }
    }
}