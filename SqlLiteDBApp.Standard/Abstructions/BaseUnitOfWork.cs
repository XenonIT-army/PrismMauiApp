using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLiteDBApp.Standard.Abstructions
{
    public abstract class BaseUnitOfWork : IUnitOfWork, IDisposable
    {
        protected DbContext db;

        public BaseUnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
