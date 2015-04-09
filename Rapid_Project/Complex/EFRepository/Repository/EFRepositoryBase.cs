using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Linq.Expressions;
using System.Data.Entity.Core;
using Complex.Repository.Utility;

namespace Complex.Repository
{
    public abstract class EFRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
       
        public EntitytoData EF ;
      
         public EFRepositoryBase()
         {
             EF = new EntitytoData();
         }
         public EFRepositoryBase(string connstr)
         { 
             EF = new EntitytoData(connstr);
         }
         public void ChangeDatabase(string connstr)
         { 
             EF = new EntitytoData(connstr); 
         }
        public DbSet<TEntity> Entities
        {
            get { return EF.Set<TEntity>(); }
        }
       
        public int Insert(TEntity entity)
        { 
            Entities.Add(entity);
            return EF.SaveChanges();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            return EF.SaveChanges();
        }
        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.AsNoTracking().Where(predicate);
        }
        public IQueryable<TEntity> GetAllNoCache()
        {
            return Entities.AsNoTracking().AsQueryable();
        }
        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
        //  //  EF.Entry(entity).State = EntityState.Modified;
        //    var Tentity = GetByKey(key);
        ////   Tentity = TObject;

        //    var entry = EF.Entry(Tentity);
        //    EF.Set<TEntity>().Attach(TObject);
        //    entry.State = EntityState.Modified; 
            return EF.SaveChanges();
        }


        //key删除
        public int DeleteByKey(object id)
        {
            ///删除操作实现 
            Entities.Remove(GetByKey(id));
            return EF.SaveChanges();
        }
        //key
        public TEntity GetByKey(object key)
        { 
            return Entities.Find(key);
        }
        ////id
        //public TEntity GetById(int key)
        //{ 
        //    return Entities.Single(e => e.Id.Equals(key)); 
        //}
        ////id
        //public int DeleteById(int id)
        //{
        //    ///删除操作实现 
        //    Entities.Remove(GetById(id));
        //    return EF.SaveChanges();
        //}
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity> SearchFor_Page<TKey>(Expression<Func<TEntity, bool>> predicate, int page, int page_size, Expression<Func<TEntity, TKey>> order, bool asc)
        {
            if (asc)
            {
                return Entities.Where(predicate).OrderBy(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            else
            {
                return Entities.Where(predicate).OrderByDescending(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity> SearchFor_Page<TKey>(int page, int page_size, Expression<Func<TEntity, TKey>> order, bool asc)
        {
            if (asc)
            {
                return Entities.OrderBy(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            else
            {
                return Entities.OrderByDescending(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
        }
        //public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
        //public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(TEntity entity)
        {
             
            try
            {
                var entry = EF.Entry(entity);
                EF.Set<TEntity>().Attach(entity);
                entry.State = EntityState.Modified;
              
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }


        public int Update(object Id, TEntity entities)  
        {
            if (EF == null) throw new ArgumentNullException("dbContext");
            if (entities == null) throw new ArgumentNullException("entities");


            DbSet<TEntity> dbSet = EF.Set<TEntity>();
            try
            {
                System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> entry = EF.Entry(entities);
                if (entry.State == EntityState.Detached)
                {
                    dbSet.Attach(entities);
                    entry.State = EntityState.Modified;
                }
            }
            catch (InvalidOperationException)
            {
                TEntity oldEntity = dbSet.Find(Id);
                EF.Entry(oldEntity).CurrentValues.SetValues(entities);
               
            }
           return SaveChanges();

        }
    }
}
