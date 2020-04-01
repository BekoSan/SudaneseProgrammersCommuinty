using System.Collections.Generic;

namespace SudaneseProgComLibrary.DataAccess
{
    public interface INoSqlDataConnection
    {
        void InsertRecord<T>(string table, T record);

        IEnumerable<T> LoadRecords<T>(string table);

        T LoadRecordById<T>(string table, int Id);

        void UpdateRecord<T>(string table, int Id, T record);
    }
}