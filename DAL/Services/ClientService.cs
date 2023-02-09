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
    public class ClientService : BaseService, IClientRepository<Client, int>
    {
      

        public ClientService(IConfiguration config) : base(config)
        {
        }

        //CRUD
        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idClient], [CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword] FROM [Client]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToClient();
          
                        }
                    }
                }
            }
        }

        public Client Get(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idClient], [CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword] WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return (reader.Read()) ? reader.ToClient(): null;
                    }
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    /* command.CommandText = @"INSERT INTO [Client] ([CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword])
                         OUTPUT [inserted].[idClient]
                         VALUES (@CliNam, @CliFirstName, @CliMail, @CliCompany, @CliLogin, HASHBYTES('SHA2_512, @CliPassword)";*/

                    command.CommandText = "SP_Client_Insert";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("name", entity.CliName);
                    command.Parameters.AddWithValue("firstname", entity.CliFirstName);
                    command.Parameters.AddWithValue("mail", entity.CliMail);
                    command.Parameters.AddWithValue("company", entity.CliCompany);
                    command.Parameters.AddWithValue("login", entity.CliLogin);
                    command.Parameters.AddWithValue("password", entity.CliPassword);

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
                    command.CommandText = @"DELETE FROM [Client] WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool Update(int id, Client entity)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [Client]
                                            SET [CliName] = @name,
                                                [CliFirstName] = @firstname,
                                                [CliMail] = @mail,
                                                [CliCompany] = @company,
                                                [CliLogin] = @login
                                           WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("name", entity.CliName);
                    command.Parameters.AddWithValue("firstname", entity.CliFirstName);
                    command.Parameters.AddWithValue("mail", entity.CliMail);
                    command.Parameters.AddWithValue("company", entity.CliCompany);
                    command.Parameters.AddWithValue("login", entity.CliLogin);
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery()>0;
                }
            }

        }

        public int? CheckPassword(string CliLogin, string CliPassword)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Client_CheckPassword";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("login", CliLogin);
                    command.Parameters.AddWithValue("password", CliPassword);

                    connection.Open();

                    return (int?)command.ExecuteScalar();
                }
            }
        }
    }
}
