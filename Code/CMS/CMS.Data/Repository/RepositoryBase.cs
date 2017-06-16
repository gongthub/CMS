using CMS.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CMS.Data
{
    public class RepositoryBase : IRepositoryBase, IDisposable
    {
        private CMSDbContext dbcontext = new CMSDbContext();
        private DbTransaction dbTransaction { get; set; }
        public IRepositoryBase BeginTrans()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            dbTransaction = dbConnection.BeginTransaction();
            return this;
        }
        public int Commit()
        {
            try
            {
                var returnValue = dbcontext.SaveChanges();
                if (dbTransaction != null)
                {
                    dbTransaction.Commit();
                }
                return returnValue;
            }
            catch (Exception)
            {
                if (dbTransaction != null)
                {
                    this.dbTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                this.Dispose();
            }
        }
        public void Dispose()
        {
            if (dbTransaction != null)
            {
                this.dbTransaction.Dispose();
            }
            this.dbcontext.Dispose();
        }
        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Verity(entity);
            dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Insert<TEntity>(List<TEntity> entitys) where TEntity : class
        {
            foreach (var entity in entitys)
            {
                Verity(entity);
                dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            Verity(entity);
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
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            dbcontext.Set<TEntity>().Attach(entity);
            dbcontext.Entry<TEntity>(entity).State = EntityState.Deleted;
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitys = dbcontext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => dbcontext.Entry<TEntity>(m).State = EntityState.Deleted);
            return dbTransaction == null ? this.Commit() : 0;
        }
        public TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return dbcontext.Set<TEntity>().Find(keyValue);
        }
        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbcontext.Set<TEntity>().FirstOrDefault(predicate);
        }
        public IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class
        {
            return dbcontext.Set<TEntity>();
        }
        public IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbcontext.Set<TEntity>().Where(predicate);
        }
        public List<TEntity> FindList<TEntity>(string strSql) where TEntity : class
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql).ToList<TEntity>();
        }
        public List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameter) where TEntity : class
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql, dbParameter).ToList<TEntity>();
        }
        public List<TEntity> FindList<TEntity>(Pagination pagination) where TEntity : class,new()
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
        public List<TEntity> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate, Pagination pagination) where TEntity : class,new()
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


        private void Verity<T>(T entity)
        {
            var type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Object[] attrs = prop.GetCustomAttributes(true);
                string strDesc = string.Empty;
                DescriptionAttribute descAttr = Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descAttr != null)
                {
                    strDesc = descAttr.Description;
                }
                foreach (Object verify in attrs)
                {
                    if (verify is VerifyAttribute)
                    {
                        CMS.Code.Enums.VerifyType[] Verifys = (verify as VerifyAttribute).Verify;
                        if (Verifys != null && Verifys.Length > 0)
                        {
                            foreach (var Verify in Verifys)
                            {
                                object val = entity.GetType().GetProperty(prop.Name).GetValue(entity, null);
                                VerityEntity(Verify, val, strDesc);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 当个字段合法性校验
        /// </summary>
        /// <param name="Verifys"></param>
        /// <param name="val"></param>
        /// <param name="desc"></param>
        private void VerityEntity(CMS.Code.Enums.VerifyType Verifys, object val, string desc)
        {
            switch (Verifys)
            {
                case Enums.VerifyType.IsNull:
                    if (val == null)
                    {
                        throw new Exception("字段 '" + desc + "'不能为空！");
                    }
                    break;
                case Enums.VerifyType.IsNullOrEmpty:
                    if (val == null || string.IsNullOrEmpty(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'不能为空！");
                    }
                    break;
                case Enums.VerifyType.IsInt:
                    if (val != null && !Code.Validate.IsNumber(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'只能为数字！");
                    }
                    break;
                case Enums.VerifyType.IsIdCard:
                    if (val != null && !Code.Validate.IsIdCard(val.ToString()))
                    {
                        throw new Exception("身份证格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsEmail:
                    if (val != null && !Code.Validate.IsEmail(val.ToString()))
                    {
                        throw new Exception("邮箱格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsPhone:
                    if (val != null && !Code.Validate.IsValidPhoneAndMobile(val.ToString()))
                    {
                        throw new Exception("手机号格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsUrl:
                    if (val != null && !Code.Validate.IsValidURL(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsIP:
                    if (val != null && !Code.Validate.IsValidIP(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomain:
                    if (val != null && !Code.Validate.IsValidDomain(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomainOrEmpty:
                    if (val != null && !string.IsNullOrEmpty(val.ToString()) && !Code.Validate.IsValidDomain(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsGuid:
                    if (val != null && !Code.Validate.IsGuid(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDate:
                    if (val != null && !Code.Validate.IsDate(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomainOrIP:
                    if (val != null && !(Code.Validate.IsValidDomain(val.ToString()) || !Code.Validate.IsValidIP(val.ToString())))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
            }
        }

    }
}
