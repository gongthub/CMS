using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SqlServerRepository
{
    public class ReportRepository : SqlServerRepositoryBase, IReportRepository
    {
        /// <summary>
        /// 获取用户站点访问数据报表
        /// </summary>
        /// <returns></returns>
        public List<WebSiteAccessReport> GetWebSiteAccessDates(string userIds)
        {
            List<WebSiteAccessReport> models = new List<WebSiteAccessReport>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select A.ShortName,A.mont,COUNT(1) as nums from (
	                            SELECT DISTINCT A.Id,A.ShortName,B.Id as accessId,YEAR(B.Date) as years,MONTH(B.Date) monT FROM (
		                            SELECT A.UserId,B.Id,B.ShortName from sys_userwebsites AS A
		                            left JOIN sys_websites as B ON A.WebSiteId=B.Id ");
            if (!string.IsNullOrEmpty(userIds))
            {
                strSql.Append(@" WHERE A.UserId=@userId ");
            }
            strSql.Append(@" ) AS A
	                            left JOIN sys_accesslog as B ON A.Id=B.WebSiteId
                            ) AS A
                            where A.years=YEAR(GETDATE())
                            group by  A.ShortName,A.mont");

            if (!string.IsNullOrEmpty(userIds))
            {
                DbParameter[] parameter = 
            {
                 new SqlParameter("@userId",userIds)
            };
                return this.FindList<WebSiteAccessReport>(strSql.ToString(), parameter);
            }
            else
            {
                return this.FindList<WebSiteAccessReport>(strSql.ToString());
            }
        }


        /// <summary>
        /// 获取当前站点访问当日数据报表
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public List<WebSiteAccessToDayReport> GetWebSiteAccessToDates(string webSiteId)
        {
            List<WebSiteAccessToDayReport> models = new List<WebSiteAccessToDayReport>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT A.Hours,COUNT(1) Nums FROM (
	                            SELECT DISTINCT B.Id as accessId,Date(B.Date) toDate,HOUR(B.Date) as Hours FROM (
		                            SELECT A.UserId,B.Id,B.ShortName from sys_userwebsites AS A
		                            left JOIN sys_websites as B ON A.WebSiteId=B.Id
	                              WHERE B.Id=@webSiteId
	                            ) AS A
	                            left JOIN sys_accesslog as B ON A.Id=B.WebSiteId
                            ) AS A
                            WHERE A.toDate=Date(GETDATE())
                            GROUP BY A.Hours");
            DbParameter[] parameter = 
            {
                 new SqlParameter("@webSiteId",webSiteId)
            };
            return this.FindList<WebSiteAccessToDayReport>(strSql.ToString(), parameter);
        }
    }
}
