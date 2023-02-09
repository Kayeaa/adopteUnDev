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
    public class DevService : BaseService, IDeveloperRepository<Developer, int>
    {
        public DevService(IConfiguration config) : base(config)
        {
        }

        //CRUD
        public IEnumerable<Developer> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToDeveloper();

                        }
                    }
                }
            }
        }

        public Developer Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer]  WHERE [idDev] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return (reader.Read()) ? reader.ToDeveloper() : null;
                    }
                }
            }
        }

        public int Insert(Developer entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_DeveloperAdd";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("DevName", entity.DevName);
                    command.Parameters.AddWithValue("DevFirstName", entity.DevFirstName);
                    command.Parameters.AddWithValue("DevBirthDate", entity.DevBirthDate);
                    command.Parameters.AddWithValue("DevPicture", (object)entity.DevPicture ?? DBNull.Value); //Can be Null
                    command.Parameters.AddWithValue("DevHourCost", entity.DevHourCost);
                    command.Parameters.AddWithValue("DevDayCost", entity.DevDayCost);
                    command.Parameters.AddWithValue("DevMonthCost", entity.DevMonthCost);
                    command.Parameters.AddWithValue("DevMail", entity.DevMail);
                    command.Parameters.AddWithValue("DevCategPrincipal", (object)entity.DevCategPrincipal ?? DBNull.Value); //Can be Null

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
                    command.CommandText = @"DELETE FROM [Developer] WHERE [idDev] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool Update(int id, Developer entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [Developer]
                                            SET [DevName] = @DevName,
                                                [DevFirstName] = @DevFirstName,
                                                [DevBirthDate] = @DevBirthDate,
                                                [DevPicture] = @DevPicture,
                                                [DevHourCost] = @DevHourCost
                                                [DevDayCost] = @DevDayCost
                                                [DevMonthCost] = @DevMonthCost
                                                [DevCategPrincipal] = @DevCategPrincipal
                                           WHERE [idDev] = @id";
                    command.Parameters.AddWithValue("DevName", entity.DevName);
                    command.Parameters.AddWithValue("DevFirstName", entity.DevFirstName);
                    command.Parameters.AddWithValue("DevBirthDate", entity.DevBirthDate);
                    command.Parameters.AddWithValue("DevPicture", entity.DevPicture);
                    command.Parameters.AddWithValue("DevHourCost", entity.DevHourCost);
                    command.Parameters.AddWithValue("DevDayCost", entity.DevDayCost);
                    command.Parameters.AddWithValue("DevMonthCost", entity.DevMonthCost);
                    command.Parameters.AddWithValue("DevMail", entity.DevMail);
                    command.Parameters.AddWithValue("DevCategPrincipal", entity.DevCategPrincipal);
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }
    }
}
