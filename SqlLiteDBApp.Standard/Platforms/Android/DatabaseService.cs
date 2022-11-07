using Android.Telephony.Data;
using SqlLiteDBApp.Standard.Interface;

namespace SqlLiteDBApp.Standard.Services
{
    // All the code in this file is only included on Android.
     partial class DatabaseService 
    {
         partial void GetDatabasePath()
        {
            AppSettings.DBPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                AppSettings.DatabaseName);
        }
    }
}