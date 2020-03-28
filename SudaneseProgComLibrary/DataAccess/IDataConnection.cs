using System.Collections.Generic;
using System.Data;

namespace SudaneseProgComLibrary.DataAccess
{
    public interface IDataConnection
    {
        /// <summary>
        /// Creates new row of in the table you selected.
        /// </summary>
        /// <typeparam name="T">The type of data model ,you want to save</typeparam>
        /// <param name="model">The data model object.</param>
        /// <param name="commandText">The text of the sql command or stored procdure , you want to perform.</param>
        /// <param name="commandType">The way you want to perform action , by stored  procedure or sql command text.</param>
        /// <returns></returns>
        T Create<T>(T model, string commandText, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Gets all the rows in table and put them in list of data model.
        /// </summary>
        /// <typeparam name="T">The type of data model, you want to get.</typeparam>
        /// <param name="commandText">The text of the sql command or stored procdure , you want to perform.</param>
        /// <param name="commandType">The way you want to perform action , by stored  procedure or sql command text.</param>
        /// <returns><see cref="List{T}"/></returns>
        List<T> Get<T>(string commandText, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Get the data model by its own id.
        /// </summary>
        /// <typeparam name="T">The data model.</typeparam>
        /// <param name="Id">The id of data model.</param>
        /// <param name="commandText">The command or stored procedure to excute.</param>
        /// <param name="commandType">command type</param>
        /// <returns></returns>
        T GetById<T>(string commandText, int Id, CommandType commandType = CommandType.StoredProcedure) where T : new();
    }
}