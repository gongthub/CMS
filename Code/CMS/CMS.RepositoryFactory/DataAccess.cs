using CMS.Domain.IRepository;
using CMS.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryFactory
{
    public sealed class DataAccess
    {
        #region 属性

        /// <summary>
        /// 调用类命名空间
        /// </summary>
        private static readonly string DLLPATH = "CMS.{0}Repository";

        /// <summary>
        /// 数据库类型
        /// </summary>
        private static readonly string DBTYPE = CMS.Code.ConfigHelp.configHelp.SYSDBTYPE;

        /// <summary>
        /// 命名空间
        /// </summary>
        private static readonly string DLLPATHHASDB = string.Format(DLLPATH, DBTYPE);

        #endregion 属性

        #region 默认方法
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string classNamespace)
        {
            //object objType = DataCache.GetCache(classNamespace);//从缓存读取
            object objType = new object();
            //if (objType == null)
            //{
            try
            {
                objType = Assembly.Load(DLLPATHHASDB).CreateInstance(classNamespace);//反射创建
                //DataCache.SetCache(classNamespace, objType);// 写入缓存
            }
            catch (Exception er)
            {
                throw er;
            }
            //}
            return objType;
        }
        #endregion 默认方法

        #region 功能：创建接口通用方法（接口名称必须等于“I”+ 数据库实现层名称）
        /// <summary>
        /// 功能：创建接口通用方法（接口名称必须等于“I”+ 数据库实现层名称） 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInterface<T>()
        {
            string ClassNamespace = DLLPATHHASDB + "." + typeof(T).Name.Substring(1);
            object objType = CreateObject(ClassNamespace);
            return (T)objType;
        }
        #endregion

        #region 自定义接口

        /// <summary>
        /// 接口ICacheRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ICacheRepository CreateICacheRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".CacheRepository";
            object objType = CreateObject(ClassNamespace);
            return (ICacheRepository)objType;
        }
        /// <summary>
        /// 接口IAccessLogRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IAccessLogRepository CreateIAccessLogRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".AccessLogRepository";
            object objType = CreateObject(ClassNamespace);
            return (IAccessLogRepository)objType;
        }
        /// <summary>
        /// 接口IAreaRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IAreaRepository CreateIAreaRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".AreaRepository";
            object objType = CreateObject(ClassNamespace);
            return (IAreaRepository)objType;
        }
        /// <summary>
        /// 接口IItemsDetailRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IItemsDetailRepository CreateIItemsDetailRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ItemsDetailRepository";
            object objType = CreateObject(ClassNamespace);
            return (IItemsDetailRepository)objType;
        }
        /// <summary>
        /// 接口IItemsRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IItemsRepository CreateIItemsRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ItemsRepository";
            object objType = CreateObject(ClassNamespace);
            return (IItemsRepository)objType;
        }
        /// <summary>
        /// 接口IModuleButtonRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IModuleButtonRepository CreateIModuleButtonRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ModuleButtonRepository";
            object objType = CreateObject(ClassNamespace);
            return (IModuleButtonRepository)objType;
        }
        /// <summary>
        /// 接口IModuleRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IModuleRepository CreateIModuleRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ModuleRepository";
            object objType = CreateObject(ClassNamespace);
            return (IModuleRepository)objType;
        }
        /// <summary>
        /// 接口IOrganizeRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IOrganizeRepository CreateIOrganizeRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".OrganizeRepository";
            object objType = CreateObject(ClassNamespace);
            return (IOrganizeRepository)objType;
        }
        /// <summary>
        /// 接口IRoleAuthorizeRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IRoleAuthorizeRepository CreateIRoleAuthorizeRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".RoleAuthorizeRepository";
            object objType = CreateObject(ClassNamespace);
            return (IRoleAuthorizeRepository)objType;
        }
        /// <summary>
        /// 接口IRoleRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IRoleRepository CreateIRoleRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".RoleRepository";
            object objType = CreateObject(ClassNamespace);
            return (IRoleRepository)objType;
        }
        /// <summary>
        /// 接口ISysColumnsRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ISysColumnsRepository CreateISysColumnsRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".SysColumnsRepository";
            object objType = CreateObject(ClassNamespace);
            return (ISysColumnsRepository)objType;
        }
        /// <summary>
        /// 接口ISysTempletItemsRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ISysTempletItemsRepository CreateISysTempletItemsRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".SysTempletItemsRepository";
            object objType = CreateObject(ClassNamespace);
            return (ISysTempletItemsRepository)objType;
        }
        /// <summary>
        /// 接口ISysTempletsRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ISysTempletsRepository CreateISysTempletsRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".SysTempletsRepository";
            object objType = CreateObject(ClassNamespace);
            return (ISysTempletsRepository)objType;
        }
        /// <summary>
        /// 接口IUpFileRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IUpFileRepository CreateIUpFileRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".UpFileRepository";
            object objType = CreateObject(ClassNamespace);
            return (IUpFileRepository)objType;
        }
        /// <summary>
        /// 接口IUserLogOnRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IUserLogOnRepository CreateIUserLogOnRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".UserLogOnRepository";
            object objType = CreateObject(ClassNamespace);
            return (IUserLogOnRepository)objType;
        }
        /// <summary>
        /// 接口IUserRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IUserRepository CreateIUserRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".UserRepository";
            object objType = CreateObject(ClassNamespace);
            return (IUserRepository)objType;
        }
        /// <summary>
        /// 接口IUserWebSiteRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IUserWebSiteRepository CreateIUserWebSiteRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".UserWebSiteRepository";
            object objType = CreateObject(ClassNamespace);
            return (IUserWebSiteRepository)objType;
        }
        /// <summary>
        /// 接口IDbBackupRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IDbBackupRepository CreateIDbBackupRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".DbBackupRepository";
            object objType = CreateObject(ClassNamespace);
            return (IDbBackupRepository)objType;
        }
        /// <summary>
        /// 接口IFilterIPRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IFilterIPRepository CreateIFilterIPRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".FilterIPRepository";
            object objType = CreateObject(ClassNamespace);
            return (IFilterIPRepository)objType;
        }
        /// <summary>
        /// 接口ILogRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ILogRepository CreateILogRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".LogRepository";
            object objType = CreateObject(ClassNamespace);
            return (ILogRepository)objType;
        }
        /// <summary>
        /// 接口IAdvancedContentConfigRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IAdvancedContentConfigRepository CreateIAdvancedContentConfigRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".AdvancedContentConfigRepository";
            object objType = CreateObject(ClassNamespace);
            return (IAdvancedContentConfigRepository)objType;
        }
        /// <summary>
        /// 接口IColumnsRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IColumnsRepository CreateIColumnsRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ColumnsRepository";
            object objType = CreateObject(ClassNamespace);
            return (IColumnsRepository)objType;
        }
        /// <summary>
        /// 接口IContentRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IContentRepository CreateIContentRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ContentRepository";
            object objType = CreateObject(ClassNamespace);
            return (IContentRepository)objType;
        }
        /// <summary>
        /// 接口IKeyWordsRespository映射 
        /// </summary>
        /// <returns></returns>
        public static IKeyWordsRespository CreateIKeyWordsRespository()
        {
            string ClassNamespace = DLLPATHHASDB + ".KeyWordsRespository";
            object objType = CreateObject(ClassNamespace);
            return (IKeyWordsRespository)objType;
        }
        /// <summary>
        /// 接口IMessageConfigRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IMessageConfigRepository CreateIMessageConfigRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".MessageConfigRepository";
            object objType = CreateObject(ClassNamespace);
            return (IMessageConfigRepository)objType;
        }
        /// <summary>
        /// 接口IMessagesRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IMessagesRepository CreateIMessagesRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".MessagesRepository";
            object objType = CreateObject(ClassNamespace);
            return (IMessagesRepository)objType;
        }
        /// <summary>
        /// 接口ITempletRepository映射 
        /// </summary>
        /// <returns></returns>
        public static ITempletRepository CreateITempletRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".TempletRepository";
            object objType = CreateObject(ClassNamespace);
            return (ITempletRepository)objType;
        }
        /// <summary>
        /// 接口IWebSiteConfigRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IWebSiteConfigRepository CreateIWebSiteConfigRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".WebSiteConfigRepository";
            object objType = CreateObject(ClassNamespace);
            return (IWebSiteConfigRepository)objType;
        }
        /// <summary>
        /// 接口IWebSiteForUrlRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IWebSiteForUrlRepository CreateIWebSiteForUrlRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".WebSiteForUrlRepository";
            object objType = CreateObject(ClassNamespace);
            return (IWebSiteForUrlRepository)objType;
        }
        /// <summary>
        /// 接口IWebSiteRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IWebSiteRepository CreateIWebSiteRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".WebSiteRepository";
            object objType = CreateObject(ClassNamespace);
            return (IWebSiteRepository)objType;
        }
        /// <summary>
        /// 接口IRequestLogRepository映射 
        /// </summary>
        /// <returns></returns>
        public static IRequestLogRepository CreateIRequestLogRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".RequestLogRepository";
            object objType = CreateObject(ClassNamespace);
            return (IRequestLogRepository)objType;
        }
        /// <summary>
        /// 接口IReportRepositoryy映射 
        /// </summary>
        /// <returns></returns>
        public static IReportRepository CreateIReportRepository()
        {
            string ClassNamespace = DLLPATHHASDB + ".ReportRepository";
            object objType = CreateObject(ClassNamespace);
            return (IReportRepository)objType;
        }
        #endregion
    }
}
