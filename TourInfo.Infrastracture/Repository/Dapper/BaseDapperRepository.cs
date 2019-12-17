using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TourInfo.Domain.Base;
using Dapper;
using DapperExtensions;
namespace TourInfo.Infrastracture.Repository.Dapper
{
    public class BaseDapperRepository<T,Key> :  IRepository<T,Key>
        where T:class
    {
        string connectionString;
       
        public BaseDapperRepository(string connectionString )
        {
            // this.connectionString = "server=.;Integrated Security=true;database=ewqy;";
            this.connectionString =connectionString;// "server=114.55.59.143,1430;uid=sa;pwd=zyzlxxjs;database=yf;";
           
            
        }
        IDbConnection _conn;
        protected IDbConnection Conn
        {
            get
            {
                _conn = _conn ?? new SqlConnection(connectionString);

                return _conn;
            }
        }
        public void Insert(T entity)
        {
             Conn.Insert (entity);
        }

        public T Get(Key id)
        {
           return Conn.Get<T>(id);
        }

        public bool Update(T entity)
        {
            return Conn.Update(entity);
        }
    }
}
