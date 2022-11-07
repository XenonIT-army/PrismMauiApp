using Ninject;
using PrismMauiApp.Interface;
using PrismMauiApp.Model;
using PrismMauiApp.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp.Service
{
    public class DBServiceManager
    {
        private StandardKernel kernel;
        public IService<Word> ProductService { get; }

        public DBServiceManager()
        {
            // var settings = new Ninject.NinjectSettings() { LoadExtensions = false };
            kernel = new StandardKernel(new DictionaryNinjectModule());
            ProductService = kernel.Get<IService<Word>>();
        }
    }
}
