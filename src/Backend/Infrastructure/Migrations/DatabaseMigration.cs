using Dapper;
using MySqlConnector;
using System.Data.Common;

namespace Infrastructure.Migrations
{
    public class DatabaseMigration
    {
        public static void Migrate(string connectionString)
        {
            EnsureDatabaseCreated(connectionString);
        }

        private static void EnsureDatabaseCreated(string connectionString)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);

            //get database name from connectionstring
            var databaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

            //verify if database exists and create if not
            if(records.Any() == false)
                dbConnection.Execute($"CREATE DATABAES {databaseName}");
        }
    }
}
