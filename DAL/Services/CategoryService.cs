using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
    public class CategoryService : BaseService, ICategoryRepository<Categories, int>
    {

        public CategoryService(IConfiguration config) : base(config)
        {
        }

        //CRUD
        public IEnumerable<Categories> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idCategory], [CategLabel] FROM [Categories]";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCategories();

                        }
                    }
                }
            }
        }

        public Categories Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idCategory], [CategLabel] WHERE [idCategory] = @id";
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return (reader.Read()) ? reader.ToCategories() : null;
                    }
                }
            }
        }

        public int Insert(Categories entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "SP_CategoriesAdd";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("CategLabel", entity.CategLabel);

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
                    command.CommandText = @"DELETE FROM [Categories] WHERE [idCategory] = @id";
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool Update(int id, Categories entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [Categories]
                                            SET [Categabel] = @CategLabel,
                                           WHERE [idCategory] = @id";
                    command.Parameters.AddWithValue("CategLabel", entity.CategLabel);
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }
    }
}
