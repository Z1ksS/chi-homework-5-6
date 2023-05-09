using System;

namespace DB.Lecture5.ADO.NET
{
    public class TaskRunner
    {
        public enum Tasks
        {
            Task1,
            Task2,
            Task3,
            Task4,
            Task5
        }

        public Tasks Task { get; set; }

        public TaskMain SelectTask(TaskRunner task)
        {
            switch(task.Task)
            {
                case TaskRunner.Tasks.Task1:
                    return new Task1();
                case TaskRunner.Tasks.Task2:
                    return new Task2();
                case TaskRunner.Tasks.Task3: 
                    return new Task3();
                case TaskRunner.Tasks.Task4:
                    return new Task4();
                case TaskRunner.Tasks.Task5:
                    return new Task5();
                default: 
                    return null;
            }
        }
    }
}
