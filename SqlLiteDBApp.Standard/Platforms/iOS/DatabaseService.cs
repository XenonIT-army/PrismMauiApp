using SqlLiteDBApp.Standard.Interface;

namespace SqlLiteDBApp.Standard.Services
{
    // All the code in this file is only included on iOS.
     partial class DatabaseService 
    {
         partial void GetDatabasePath()
        {
            AppSettings.DBPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
                "..",
                "Library",
                AppSettings.DatabaseName);
        }
    }
}