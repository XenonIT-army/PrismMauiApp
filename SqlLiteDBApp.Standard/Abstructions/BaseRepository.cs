﻿using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Context;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SqlLiteDBApp.Standard.Abstructions
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext db;

        public BaseRepository(DbContext db)
        {
            this.db = db;
        }

       
        public TEntity Create(TEntity entity)
        {
            return db.Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

      
        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entity)
        {
         
            db.Set<TEntity>().UpdateRange(entity);
           
        }

        public int GetLast(Func<TEntity, int> key)
        {
            return db.Set<TEntity>().Max(key);
        }
    }
}
