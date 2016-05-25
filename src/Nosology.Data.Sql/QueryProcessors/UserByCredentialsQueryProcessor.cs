using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Escyug.Nosology.Data.Entities;
using Escyug.Nosology.Data.QueryProcessors;


namespace Escyug.Nosology.Data.Sql.QueryProcessors
{
    public sealed class UserByCredentialsQueryProcessor : IUserByCredentialsQueryProcessor
    {
        private readonly string _connectionString;

        public UserByCredentialsQueryProcessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> GetUserAsync(string login, string password)
        {
            SqlConnection connection = null;

            try
            {
                using(connection = new SqlConnection(_connectionString))
                {
                   
                    await connection.OpenAsync();

                    /* 
                     * Since none of the rows are likely to be large, 
                     * we will execute this without specifying a CommandBehavior
                     * This will cause the default (non-sequential) access mode to be used
                     */
                    using (var command = CreateSelectCommnad(login, password, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            // Always use ReadAsync
                            if (await reader.ReadAsync())
                            {
                                var user = GetUserFromReader(reader);
                                return user;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            // exception handling
            catch (SqlException)
            {
                if (connection != null)
                {
                    connection = null;
                }

                return null;
            }
        }

        private SqlCommand CreateSelectCommnad(string login, string password, SqlConnection connection)
        {
            var commandText = @"SELECT PAROL, DATE_E, NIC, KAT  FROM dbo.DOPUSK WHERE  (NIC = @NIC) AND (PAROL = @PAROL)";
            var commandType = CommandType.Text;
            var parameters = new SqlParameter[] {
                new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", DataRowVersion.Current, null),
                new SqlParameter("@NIC", SqlDbType.NChar, 20),
                new SqlParameter("@PAROL", SqlDbType.NChar, 20)};

            var command = new SqlCommand(commandText, connection);

            command.CommandType = commandType;
            command.Parameters.AddRange(parameters);
            command.Parameters["@NIC"].Value = login;
            command.Parameters["@PAROL"].Value = password;

            return command;
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            /** Data columns order :
             *   0 - PAROL
             *   1 - DATE_E
             *   2 - NIC
             *   3 - KAT
             */

            var expiredDate = reader.GetFieldValue<DateTime>(1);
            var userName = reader.GetFieldValue<string>(2);
            var userLevel = reader.GetFieldValue<int>(3);

            return new User(userName, userLevel, expiredDate);
        }
    }
}
