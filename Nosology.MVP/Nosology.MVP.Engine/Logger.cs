using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Escyug.Nosology.MVP.Engine
{
    public class Logger
    {
        private const int LOGIN_SIZE_THRESHOLD = 20;
        private const int PWD_SIZE_THRESHOLD = 5;

        private const string PROVIDER_NAME = "System.Data.SqlClient";
        private const string CONNECTION_STRING = "Data Source=sql04.corp.parking.ru;Initial Catalog=escyug-6; Persist Security Info=True;User ID=escyug-6;Password=pgpFmvk5";
            //"Data Source=localhost;Initial Catalog=REGISTR; Integrated Security=True";
        private const string COMMAND_TEXT = @"SELECT PAROL, DATE_E, NIC, KAT
                                        FROM dbo.DOPUSK 
                                   WHERE  NIC = @NIC";

        private readonly string[] LEVELS = new string[] 
        {
            "Администратор",
            "Орган управления здравоохранением субъекта Российской федерации",
            "Орган управления здравоохранением муниципального образования субъекта Российской федерации",
            "Лечебно-профилактическое учреждение",
            "Аптечное учреждение"
        };
        
        public Logger()
        {

        }

        private DataTable LoadData(DbCommand command, DbConnection connection)
        {
            DataTable dat = new DataTable("DOPUSK");

            connection.Open();

            using (DbDataReader reader = command.ExecuteReader())
                dat.Load(reader);

            connection.Close();
            
            return dat;
        }

        private string[] CheckData(DataTable data, string inputPwd)
        {
            string[] userInfo;

            if (data != null && data.Rows.Count != 0)
            {
                DateTime currentDate = DateTime.Today;

                string refPwd = data.Rows[0]["PAROL"].ToString().Trim();
                DateTime refDate = (DateTime)data.Rows[0]["DATE_E"];

                if (inputPwd.ToLower() == refPwd.ToLower() && currentDate <= refDate)
                { 
                    string userName = data.Rows[0]["NIC"].ToString().Trim();
                    string userLevel = LEVELS[(int)data.Rows[0]["KAT"]];
                    
                    userInfo = new string[3] 
                    {
                        "true",
                        userName,
                        userLevel
                    };

                    return userInfo;
                }
            }

            userInfo = new string[2] { "false", "error" };
            return userInfo;
        }

        public string[] Logon(string mcod, string inputPwd)
        {
            string[] userInfo;

            if (mcod.Length > LOGIN_SIZE_THRESHOLD || inputPwd.Length > PWD_SIZE_THRESHOLD)
            {
                return userInfo = new string[2] { "false", "Login error" };
            }
            else
            {
                try
                {
                    DbConnection connection =
                        DbFactory.CreateDbConnection(PROVIDER_NAME, CONNECTION_STRING);

                    DbCommand command =
                        DbFactory.CreateCommand(COMMAND_TEXT, connection);

                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
                    new System.Data.SqlClient.SqlParameter("@NIC", System.Data.SqlDbType.NVarChar, 20)});

                    command.Parameters["@NIC"].Value = mcod;

                    DataTable userData = LoadData(command, connection);
                    userInfo = CheckData(userData, inputPwd);

                    return userInfo;

                }
                catch (DbException)
                {
                    return userInfo = new string[2] { "false", "Server error" };
                }
            }
        }
    }
}
