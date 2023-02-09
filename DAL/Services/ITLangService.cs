using Common.Repositories;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ITLangService : BaseService, IITLangRepository<ITLang, int>
    {

        public ITLangService(IConfiguration config) : base(config)
        {
        }

        //CRUD
        public IEnumerable<ITLang> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idIT], [ITLabel] FROM [ITLang]";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToITLang();
          
                        }
                    }
                }
            }
        }

        public ITLang Get(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idIT], [ITLabel] WHERE [idIT] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return (reader.Read()) ? reader.ToITLang(): null;
                    }
                }
            }
        }

        public int Insert(ITLang entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "SP_ITLangAdd";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("ITLabel", entity.ITLabel);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM [ITLang] WHERE [idIT] = @id";
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool Update(int id, ITLang entity)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [ITLang]
                                            SET [ITLabel] = @ITLabel,
                                           WHERE [idIT] = @id";
                    command.Parameters.AddWithValue("ITLabel", entity.ITLabel);
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery()>0;
                }
            }

        }
    }
}
