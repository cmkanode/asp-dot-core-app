using System.Collections.Generic;

namespace cmkService.Models
{
    public interface ITaskRepository
    {
        void Add(Task task);
        IEnumerable<Task> GetAll();
        Task Find(int id);
        Task Remove(int id);
        void Update(Task task);
    }
}