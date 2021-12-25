using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpf22.Models.Interfaces;

namespace Wpf22.Services.Interfaces
{
    internal interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
        bool Remove(T item);
        void Update(int id, T item);
    }
}
