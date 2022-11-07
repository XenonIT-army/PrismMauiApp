using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Abstructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlLiteDBApp.Standard.Repositories
{
   public class HitoryRepository : BaseRepository<PurchaseHistory>
    {
        public HitoryRepository(DbContext db) : base(db)
        {

        }

    }
}
