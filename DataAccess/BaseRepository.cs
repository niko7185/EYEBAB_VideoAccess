using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class BaseRepository<T> : IRepository<T>
    {

        protected readonly string connectionString = @"Data Source=CVDB3,1444;Initial Catalog=NikoPortDb;Integrated Security=True";
        protected SqlConnection connection;

        public BaseRepository()
        {
            connection = new SqlConnection(connectionString);
        }

        public IEnumerable<T> GetAll(string sql)
        {

            List<T> allData = new List<T>();

            return allData;

        }

        public T GetBy(string table, int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
