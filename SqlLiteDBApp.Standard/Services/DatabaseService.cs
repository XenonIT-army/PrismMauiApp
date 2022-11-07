using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDBApp.Standard.Services
{
    public partial class DatabaseService
    {
        public DatabaseService()
        {
            GetDatabasePath();
        }
         partial void GetDatabasePath();
    }
}
