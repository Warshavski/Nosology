using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace Escyug.Nosology.MVP.DataAccessLayer.Common
{

    /// <summary>
    /// get particular connection string 
    /// </summary>
    /** TODO
      *   1. use enum instead of strings parameters in dictionary
      *   2.  */
    internal enum ConnectionType { azure, local };

    internal static class ConnectionFactory
    {
        public static SqlConnection Create(string connectionType)
        {
            string providerName =
                ConfigurationManager.ConnectionStrings[connectionType].ProviderName;

            string connectionString =
                ConfigurationManager.ConnectionStrings[connectionType].ConnectionString;

            return (SqlConnection)DataFactory.CreateConnection(providerName, connectionString);
        }
    }


    //static ConnectionFactory()
    //{
    //    _connectionStrings.Add("rlsLocal", 
    //        "Data Source=MILNIKOVP;Initial Catalog=rls;Integrated Security=True");
    //    _connectionStrings.Add("lissLocal", 
    //        "Data Source=MILNIKOVP;Initial Catalog=Liss;Integrated Security=True");
    //    _connectionStrings.Add("lissMergedLocal", 
    //        "Data Source=MILNIKOVP;Initial Catalog=lissMerged;Integrated Security=True");
    //    _connectionStrings.Add("lissMergedAzure", 
    //        "Server=tcp:nfryyz91n6.database.windows.net,1433;Database=lissMerged;User ID=escyug@nfryyz91n6;Password=pgpFmvk5;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    //}
}