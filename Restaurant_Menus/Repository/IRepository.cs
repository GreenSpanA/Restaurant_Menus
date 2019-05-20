using Restaurant_Menus.Models;
using System.Collections.Generic;

namespace Restaurant_Menus.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();

        int FindCurrentFile(T item);
        int FindCurrentFileByID(int id);

    }
}
