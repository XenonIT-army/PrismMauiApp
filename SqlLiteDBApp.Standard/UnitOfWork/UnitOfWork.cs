using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Interface;
using SqlLiteDBApp.Standard.Abstructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLiteDBApp.Standard.UnitOfWork
{
    public class UnitOfWork : BaseUnitOfWork
    {
        public IRepository<WordDB> WordsRepository { get; }
       // public IRepository<PurchaseHistory> PurchaseHistory { get; }
        public UnitOfWork(DbContext db,
                                 IRepository<WordDB> wordsRepository/*, IRepository<PurchaseHistory> purchaseHistory*/) : base(db)
        {
            this.WordsRepository = wordsRepository;
           // this.PurchaseHistory = purchaseHistory;
        }
    }
}
