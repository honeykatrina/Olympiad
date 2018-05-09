using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
