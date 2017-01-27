using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using LiteDB;

namespace cmkService.Models
{
    public class TaskRepository : ITaskRepository
    {
        //private static ConcurrentDictionary<int, Task> _tasks = new ConcurrentDictionary<int, Task>();
        private static LiteDatabase db;// = new LiteDatabase("./Data/cmkData.db");
        private static LiteCollection<Task> _tasks;// = db.GetCollection<Task>("tasks");
        
        public TaskRepository()
        {
            db = new LiteDatabase("./Data/cmkData.db");
            _tasks = db.GetCollection<Task>("tasks");
            Add(new Task { Name = "Node.js", Description = "Create Node.js app", Priority = 1, IsCompleted = false });
        }

        public IEnumerable<Task> GetAll()
        {
            return _tasks.Find(Query.All());
        }

        public void Add(Task task)
        {
            task.Id = 1;
            Task t = _tasks.FindOne(Query.All(Query.Descending));
            if(t != null){
                task.Id = t.Id + 1;
            }
            _tasks.Insert(task);
        }

        public Task Find(int id)
        {
            Task task = _tasks.FindById(id);
            return task;
        }

        public Task Remove(int id)
        {
            Task task = _tasks.FindById(id);
            _tasks.Delete(id);
            return task;
        }

        public void Update(Task task)
        {
            _tasks.Update(task);
        }
    }
}