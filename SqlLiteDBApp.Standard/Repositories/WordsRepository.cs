using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Abstructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteApp.Standard.Repositories
{
    public class WordsRepository : BaseRepository<WordDB>
    {

        public WordsRepository(DbContext db) : base(db)
        {

        }
    }
}
