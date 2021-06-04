using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using grep_food.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace grep_food.DataAccess
{
    public class DataContext : DbContext, IDataRepository, IUnitOfWork
    {
      

     
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
            
        }

        public void Commit()
        {
            SaveChanges();
        }

        public DbSet<BaseIngredient> baseIngredient { get; set; }
        public DbSet<Recipe> recipe { get; set; }
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
