﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace grep_food.DataAccess
{
    public class DataContext : DbContext, IDataRepository, IUnitOfWork
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (options.IsConfigured == false)

        //        //options. ("Data Source=(localdb)\\ProjectsV13;Initial Catalog=grep-food.database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
        public override string ToString()
        {
            return "Oh bo";
        }
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
            
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Delete(entity);
        }

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
            return Insert(entity);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var registrar = this.GetService<IEntityTypeConfigurationRegistrar>();
            registrar.ApplyConfiguration(modelBuilder);
        }
    }
}
