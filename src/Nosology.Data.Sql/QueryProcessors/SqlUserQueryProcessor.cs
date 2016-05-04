using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Nosology.Data.Entities;
using Escyug.Nosology.Data.QueryProcessors;

namespace Escyug.Nosology.Data.Sql.QueryProcessors
{
    public sealed class SqlUserQueryProcessor : IUserQueryProcessor
    {
        private readonly string _connectionString;

        public SqlUserQueryProcessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        private DataTable SelectUserData(string login, string password)
        {
            DataTable userData = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(_connectionString); 

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

                userData = new DataTable("Table");
                using (connection)
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        userData.Load(reader);
                }
            }
            // exception handling
            catch (SqlException)
            {
                if (connection != null)
                {
                    connection = null;
                    userData = null;
                }

                throw new TimeoutException();
            }

            return userData;
        }

        public User SelectUser(string login, string password)
        {
            DataTable userData = SelectUserData(login, password);

            if (userData == null || userData.Rows.Count == 0)
                return null;

            var userName = userData.Rows[0]["NIC"].ToString();
            var userPassword = userData.Rows[0]["PAROL"].ToString();

            // test
            DateTime expiredDate = DateTime.Now;

            int userLevel = -1;
            int.TryParse(userData.Rows[0]["KAT"].ToString(), out userLevel);

            return new User(userName, userLevel, expiredDate);
        }
    }
}
