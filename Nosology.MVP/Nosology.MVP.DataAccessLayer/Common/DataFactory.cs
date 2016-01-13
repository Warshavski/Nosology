using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Escyug.Nosology.MVP.DataAccessLayer.Common
{
    internal static class DataFactory
    {
        /// <summary>
        /// Create DbConnection instance
        /// </summary>
        /// <param name="providerName">Name of data provider</param>
        /// <param name="connectionString">Connection string</param>
        /// <returns>DbConnection</returns>
        public static DbConnection CreateConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (DbException)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                        connection = null;
                }
            }
            // Return the connection.
            return connection;
        }

        /// <summary>
        /// Create DbCommand instance
        /// </summary>
        /// <param name="connection">DbConnection instance</param>
        /// <param name="commandText">Command text</param>
        /// <param name="commandType">Command type</param>
        /// <param name="parameters">Parameters of command</param>
        /// <returns>DbCommand</returns>
        public static DbCommand CreateCommand(DbConnection connection, string commandText,
            CommandType commandType, DbParameter[] parameters)
        {
            DbCommand command = null;

            if (commandText != null)
            {
                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = commandText;
                    command.CommandType = commandType;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                }
                catch (DbException)
                {
                    // Set the command to null if it was created.
                    if (command != null)
                        command = null;
                }
            }
            // Return the connection.
            return command;
        }

        /// <summary>
        /// Select and serialize data using SqlCommand
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <returns>Serialized data</returns>
        public static DataTable GetData(SqlCommand command)
        {
            DataTable dtData = new DataTable("Table");
            using (SqlDataReader reader = command.ExecuteReader())
                dtData.Load(reader);
            return dtData;
        }
    }

}