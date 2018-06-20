using System;
using System.Collections.Generic;
using System.Text;

namespace TrueStudio.DAO
{
    public interface ICRUD<T> : IDisposable
    {
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
        T Get(int id);
        IList<T> GetAll();
    }
}
