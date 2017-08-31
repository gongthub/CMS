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
	                            select A.ShortName,A.monT from (
		                            select A.UserId,B.Id,B.ShortName,YEAR(C.Date) as years,MONTH(C.Date) monT from sys_userwebsites as A
		                            LEFT JOIN sys_websites as B ON A.WebSiteId=B.Id AND B.DeleteMark!=1
		                            left JOIN sys_accesslog as C ON B.Id=C.WebSiteId
	                            ) AS A
	                            where ");
            if (!string.IsNullOrEmpty(userIds))
            {
                strSql.Append(@" A.UserId=@userId and ");
            }
            strSql.Append(@"A.years=YEAR(NOW())
                            ) AS A
                            GROUP BY A.ShortName,A.monT");
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
    }
}
