using CMS.Application.SystemManage;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class ReportController : ControllerBase
    {
        public ActionResult AccessDay()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult GetAccessDayDates()
        {
            DateTime EndDate = DateTime.Now.Date;
            DateTime StartDate = DateTime.Now.AddMonths(-1).Date;
            //日期坐标集合
            List<string> days = GetDayList(StartDate, EndDate);

            AccessLogApp accessLogApp = new AccessLogApp();
            List<AccessLogEntity> models = accessLogApp.GetListByDate(Base_WebSiteId,StartDate, EndDate);
            //总访问量集合
            List<string> allDatas = GetAllDatas(models, StartDate, EndDate);
            //老客户访问量集合
            List<string> oldDatas = GetOldDatas(models, StartDate, EndDate);
            //新客户访问量集合
            List<string> newDatas = GetNewDatas(allDatas, oldDatas);

            var jsons = new { xAxisdata = days, allDatas = allDatas, newDatas = newDatas, oldDatas = oldDatas };
            return Json(jsons);
        }

        private List<string> GetDayList(DateTime startDate, DateTime endDate)
        {
            List<string> days = new List<string>();
            int iday = GetDays(startDate, endDate);
            for (int i = 0; i < iday; i++)
            {
                string daysT = startDate.ToString("yyyy/MM/dd");
                days.Add(daysT);
                startDate = startDate.AddDays(1);
            }
            return days;
        }


        private List<string> GetAllDatas(List<AccessLogEntity> models, DateTime startDate, DateTime endDate)
        {
            List<string> days = new List<string>();
            int iday = GetDays(startDate, endDate);
            for (int i = 0; i < iday; i++)
            {

                DateTime startDateT = startDate.AddDays(1);
                int dayCount = models.Count(m => startDate.Date <= m.Date.Date && m.Date.Date < startDateT.Date);
                days.Add(dayCount.ToString());
                startDate = startDate.AddDays(1);
            }
            return days;
        }
        private List<string> GetNewDatas(List<string> allDatas, List<string> oldDatas)
        {
            List<string> days = new List<string>();
            if (allDatas != null && allDatas.Count > 0
                && oldDatas != null && oldDatas.Count == allDatas.Count)
            {
                for (int i = 0; i < allDatas.Count; i++)
                {
                    int allCount = 0;
                    int oldCount = 0;
                    int newCount = 0;
                    Int32.TryParse(allDatas[i], out allCount);
                    Int32.TryParse(oldDatas[i], out oldCount);
                    newCount = allCount - oldCount;
                    days.Add(newCount.ToString());
                }
            }
            return days;
        }
        private List<string> GetOldDatas(List<AccessLogEntity> models, DateTime startDate, DateTime endDate)
        {
            List<string> days = new List<string>();
            int iday = GetDays(startDate, endDate);
            for (int i = 0; i < iday; i++)
            {

                DateTime startDateT = startDate.AddDays(1);

                List<AccessLogEntity> modelsT = models.Where(m => startDate.Date <= m.Date.Date && m.Date.Date < startDateT.Date).ToList();
                List<AccessLogEntity> modelsAllT = models.Where(m => m.Date.Date < startDate.Date).ToList();
                List<AccessLogEntity> modelsTemp = (from list in modelsT
                                                    join all in modelsAllT on list.ClientID equals all.ClientID
                                                    select list).Distinct().ToList();

                int dayCount = modelsTemp.Count();
                days.Add(dayCount.ToString());
                startDate = startDate.AddDays(1);
            }
            return days;
        }

        #region 获取时间段天数
        /// <summary>
        /// 获取时间段天数
        /// </summary>
        /// <returns></returns>
        public int GetDays(DateTime start, DateTime end)
        {
            int day = 0;

            while (start <= end)
            {
                day++;
                start = start.AddDays(1);
            }

            return day;
        }

        #endregion
    }
}
