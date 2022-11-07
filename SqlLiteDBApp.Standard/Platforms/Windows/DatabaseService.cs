using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SqlLiteDBApp.Standard.Interface;

namespace SqlLiteDBApp.Standard.Services
{
    // All the code in this file is only included on Windows.

     public partial class DatabaseService 
    {
         partial void GetDatabasePath()
        {
            AppSettings.DBPath = Path.Combine(FileSystem.AppDataDirectory,
                AppSettings.DatabaseName);
        }
    }
}