using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRepository<T>
    {

        IEnumerable<T> GetAll(string sql);

        T GetBy(string table, int id);

        void Update();

    }
}
