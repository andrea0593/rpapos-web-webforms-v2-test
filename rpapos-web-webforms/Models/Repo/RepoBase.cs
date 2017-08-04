using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpapos_web_webforms.Models.Repo
{


    public abstract class RepoBase<T> where T : class
    {
        public SqlConnection connection;

        public RepoBase(string connectionString)
        {

            connection = new SqlConnection(connectionString);
        }

        public abstract T PopulateRecord(SqlDataReader reader);






        protected T GetRecord(SqlCommand command)
        {
            T record = null;
            command.Connection = connection;
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader);
                        break;
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return record;
        }



        protected bool NonQuery(SqlCommand command)
        {
            var record = 0;
            command.Connection = connection;
            connection.Open();
            try
            {
                record = command.ExecuteNonQuery();


            }
            finally
            {
                connection.Close();
            }
            return record > 0;
        }


        protected IEnumerable<T> GetRecords(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = connection;
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(PopulateRecord(reader));
                }
                finally
                {

                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return list;
        }


    }

}