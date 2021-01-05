using Todo;
using System;
using System.Collections.Generic;
using Observer;

namespace TodosPrinter
{

    public class StatsPrinter: Observer.IObserver
    {
        public void Notify(List<Task> todos)
        {
            int count = 0;
            int done = 0;
            int yetToDo = 0;
            foreach (Task task in todos)
            {
                count++;
                if (task.Done)
                {
                    done++;
                }
                else
                {
                    yetToDo++;
                }
            }
            Console.WriteLine($"\nTasks Count: {count}, done: {done}, yet to do: {yetToDo}");
        }
    }

    public class AllTaskPrinter: IObserver
    {
        public void Notify(List<Task> todos)
        {
            foreach (Task task in todos)
            {
                if (task.Done)
                {
                    Console.WriteLine($"\n[X] {task.Name}");
                }
                else
                {
                    Console.WriteLine($"\n[ ] {task.Name}");
                }
            }
        }
    }

    public class YetToDoPrinter: IObserver
    {
        public void Notify(List<Task> todos)
        {
            Console.WriteLine($"\nTo do :");
            foreach (Task task in todos)
            {
                if (!task.Done)
                {
                    Console.WriteLine($"\n- {task.Name}");
                }
            }
        }
    }

}