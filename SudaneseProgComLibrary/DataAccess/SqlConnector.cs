﻿using Dapper;
using System.Collections.Generic;
using System.Data;

namespace SudaneseProgComLibrary.DataAccess
{
    /// <summary>
    /// Class that used to work with sql data base.
    /// </summary>
    public class SqlConnector : IDataConnection
    {
        /// <summary>
        /// The name of your connection string in app.config file.
        /// </summary>
        private const string db = "Localhost";

        public T Create<T>(T model, string commandText, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.GetConnectionString(db)))
            {
                connection.Execute(commandText, DapperHelper.GenerateParameters(model, false), commandType: commandType);

                return model;
            }
        }

        public List<T> Get<T>(string commandText, CommandType commandType = CommandType.StoredProcedure)
        {
            List<T> output = new List<T>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.GetConnectionString(db)))
            {
                output = connection.Query<T>(commandText, commandType: commandType).AsList();

                return output;
            }
        }
    }
}