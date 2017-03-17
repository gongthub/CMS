using CMS.Code;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CMS.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,new()
    {
        public CMSDbContext dbcontext = null;

        public RepositoryBase()
        {
            if (dbcontext == null)
            {
                dbcontext = new CMSDbContext();
            }
        }
        public int Insert(TEntity entity)
        {
            RemoveHoldingEntityInContext(entity);
            dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            return dbcontext.SaveChanges();
        } 
        public int Insert(List<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                RemoveHoldingEntityInContext(entity);
                dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            }
            return dbcontext.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            RemoveHoldingEntityInContext(entity);
            dbcontext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    if (prop.GetValue(entity, null).ToString() == "&nbsp;")
                        dbcontext.Entry(entity).Property(prop.Name).CurrentValue = null;
                    dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }
            return dbcontext.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            RemoveHoldingEntityInContext(entity);
            dbcontext.Set<TEntity>().Attach(entity);
            dbcontext.Entry<TEntity>(entity).State = EntityState.Deleted;
            return dbcontext.SaveChanges();
        }
        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitys = dbcontext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => dbcontext.Entry<TEntity>(m).State = EntityState.Deleted);
            return dbcontext.SaveChanges();
        }
        public int DeleteById(TEntity entity)
        {
            RemoveHoldingEntityInContext(entity);
            //var entity = this as IDeleteAudited;
            dbcontext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.ToLower() == "DeleteMark".ToLower())
                {
                    dbcontext.Entry(entity).Property(prop.Name).CurrentValue = true;
                    dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                }
                if (prop.Name.ToLower() == "DeleteUserId".ToLower())
                {
                    var LoginInfo = OperatorProvider.Provider.GetCurrent();
                    if (LoginInfo != null)
                    {
                        dbcontext.Entry(entity).Property(prop.Name).CurrentValue = LoginInfo.UserId;
                        dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                    }
                }
                if (prop.Name.ToLower() == "DeleteTime".ToLower())
                {
                    dbcontext.Entry(entity).Property(prop.Name).CurrentValue = DateTime.Now;
                    dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }
            return dbcontext.SaveChanges();
        }

        public int DeleteById(Expression<Func<TEntity, bool>> predicate)
        {
            var entitys = dbcontext.Set<TEntity>().Where(predicate).ToList();
            for (int i = 0; i < entitys.Count; i++)
            {
                RemoveHoldingEntityInContext(entitys[i]);
                dbcontext.Set<TEntity>().Attach(entitys[i]);
                PropertyInfo[] props = entitys[i].GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name.ToLower() == "DeleteMark".ToLower())
                    {
                        dbcontext.Entry(entitys[i]).Property(prop.Name).CurrentValue = true;
                        dbcontext.Entry(entitys[i]).Property(prop.Name).IsModified = true;
                    }
                    if (prop.Name.ToLower() == "DeleteUserId".ToLower())
                    {
                        var LoginInfo = OperatorProvider.Provider.GetCurrent();
                        if (LoginInfo != null)
                        {
                            dbcontext.Entry(entitys[i]).Property(prop.Name).CurrentValue = LoginInfo.UserId;
                            dbcontext.Entry(entitys[i]).Property(prop.Name).IsModified = true;
                        }
                    }
                    if (prop.Name.ToLower() == "DeleteTime".ToLower())
                    {
                        dbcontext.Entry(entitys[i]).Property(prop.Name).CurrentValue = DateTime.Now;
                        dbcontext.Entry(entitys[i]).Property(prop.Name).IsModified = true;
                    }
                }
            }
            return dbcontext.SaveChanges();
        }

        public TEntity FindEntity(object keyValue)
        {
            return dbcontext.Set<TEntity>().Find(keyValue);
        }
        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return dbcontext.Set<TEntity>().FirstOrDefault(predicate);
        }
        public IQueryable<TEntity> IQueryable()
        {
            return dbcontext.Set<TEntity>();
        }
        public IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return dbcontext.Set<TEntity>().Where(predicate);
        }
        public List<TEntity> FindList(string strSql)
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql).ToList<TEntity>();
        }
        public List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql, dbParameter).ToList<TEntity>();
        }
        public List<TEntity> FindList(Pagination pagination)
        {
            bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
            string[] _order = pagination.sidx.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = dbcontext.Set<TEntity>().AsQueryable();
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(TEntity), "t");
                var property = typeof(TEntity).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<TEntity>(resultExp);
            pagination.records = tempData.Count();
            tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
            return tempData.ToList();
        }
        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
        {
            bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
            string[] _order = pagination.sidx.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = dbcontext.Set<TEntity>().Where(predicate);
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(TEntity), "t");
                var property = typeof(TEntity).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<TEntity>(resultExp);
            pagination.records = tempData.Count();
            tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
            return tempData.ToList();
        }
         

        //用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        private Boolean RemoveHoldingEntityInContext(TEntity entity)
        {
            var objContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
            var objSet = objContext.CreateObjectSet<TEntity>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }
    }
}
