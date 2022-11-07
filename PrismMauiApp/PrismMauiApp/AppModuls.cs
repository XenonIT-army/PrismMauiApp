using PrismMauiApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp
{
    public class AppModuls
    {
        public DBServiceManager DBServiceManager { get; }

        public  AppModuls()
        {
            DBServiceManager = new DBServiceManager();
        }
    }
}
