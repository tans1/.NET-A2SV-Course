public interface ITask
{
    Task GetAllTasks();
    Task GetTasksByCategory(string category);
    Task AddTask(MyTask newTask);

}

