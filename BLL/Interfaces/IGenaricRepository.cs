using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGenaricRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int add(T entity);
        int update(T entity);
        int delete(T entity);

    }
}
