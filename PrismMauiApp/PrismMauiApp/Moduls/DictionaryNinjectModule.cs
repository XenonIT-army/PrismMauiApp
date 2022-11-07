using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using PrismMauiApp.Interface;
using PrismMauiApp.Model;
using PrismMauiApp.Service;
using SqlliteApp.Standard.Repositories;
using SqlLiteDBApp.Standard.Context;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp.Moduls
{
    public class DictionaryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<WordDB>>().To<WordsRepository>();
            Bind<IService<Word>>().To<WordService>();

           // Bind<IRepository<PurchaseHistory>>().To<HitoryRepository>();
           // Bind<IService<History>>().To<HitoryService>();

            Bind<DbContext>().To<MobileContext>();
        }
    }
}
