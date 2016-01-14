using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Escyug.Nosology.MVP.DataAccessLayer.Common;

namespace Escyug.Nosology.MVP.DataAccessLayer.Sql
{
    public sealed class UserService
    {
        private string _connectionString;
        private string _providerName;

        public UserService()
        {
            _connectionString = @"Data Source=sql04.corp.parking.ru;Initial Catalog=escyug-6; Persist Security Info=True;User ID=escyug-6;Password=pgpFmvk5";
            _providerName = "System.Data.SqlClient";
        }

        public DataTable GetUserData(string login)
        {
            DataTable userData = null;
            DbConnection connection = null;

            try
            {
                connection = DataFactory.CreateConnection(_providerName, _connectionString); //ConnectionFactory.Create("parking");

                var commandText = @"SELECT PAROL, DATE_E, NIC, KAT  FROM dbo.DOPUSK WHERE  NIC = @NIC";
                var commandType = CommandType.Text;

                var parameters = new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
                    new System.Data.SqlClient.SqlParameter("@NIC", System.Data.SqlDbType.NVarChar, 20)};

                var command = DataFactory.CreateCommand(connection, commandText, commandType, parameters);
                command.Parameters["@NIC"].Value = login;

                userData = new DataTable();
                using (connection)
                {
                    connection.Open();
                    userData = DataFactory.GetData(command as SqlCommand);
                    connection.Close();
                }
            }
            catch (DbException)
            {
                if (connection != null)
                    connection = null;
            }

            return userData;
        }
    }
}
