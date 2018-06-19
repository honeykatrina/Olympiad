using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IService<T> where T : class
    {
        void AddNewItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);
        T GetItem(int? id);
        IEnumerable<T> GetItems();
        void Dispose();
    }
}
