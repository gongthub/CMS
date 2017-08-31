using Newtonsoft.Json;
using ProcessIp.Model;
using ProcessIp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProcessIp.Service
{
    public class ProcessService
    {
        public static DJS.SDK.ILog iLog = null;
        public ProcessService()
        {
            iLog = DJS.SDK.DataAccess.CreateILog();
        }
        public void InitIp()
        {
            InitAccessLogIp();
            InitRequestLogIp();
        }

        private void InitAccessLogIp()
        {
            if (ConstUtility.DbType == "mysql")
            {
                InitAccessLogIpForMySql();
            }
            else
                if (ConstUtility.DbType == "sqlserver")
                {
                    InitAccessLogIpForSqlServer();
                }
        }
        private void InitRequestLogIp()
        {
            if (ConstUtility.DbType == "mysql")
            {
                InitRequestLogIpForMySql();
            }
            else
                if (ConstUtility.DbType == "sqlserver")
                {
                    InitRequestLogIpForSqlServer();
                }
        }

        private void InitAccessLogIpForMySql()
        {
            InitAccessLogIpLocalForMySql();

            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<AccessLogEntity> models = dbContext.AccessLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();

            List<string> IpLst = models.Select(m => m.IPAddress).Distinct().ToList();
            if (IpLst != null && IpLst.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (string IpAddress in IpLst)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(IpAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(IpAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(AccessLogEntity accessModel)
                                    {
                                        if (accessModel.IPAddress == IpAddress)
                                        {
                                            accessModel.Country = data.country;
                                            accessModel.CountryNo = data.country_id;
                                            accessModel.BigArea = data.area;
                                            accessModel.Isp = data.isp;
                                            accessModel.Province = data.region;
                                            accessModel.City = data.city;
                                            accessModel.Area = data.county;
                                            accessModel.IsProcessIp = true;
                                            dbContext.AccessLogEntitys.Add(accessModel);
                                            dbContext.Entry<AccessLogEntity>(accessModel).State = EntityState.Modified;
                                            dbContext.SaveChanges();
                                        }
                                    });
                                }
                            }
                            else
                            {
                                iLog.WriteLog("InitAccessLogIpForMySql：未获取到结果", 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            iLog.WriteLog("InitAccessLogIpForMySql：处理异常：" + ex.Message, 1);
                        }
                    }
                    iLog.WriteLog("InitAccessLogIpForMySql：当前处理条数：" + num + " 总条数：" + models.Count, 0);
                    num++;
                }
            }
        }
        private void InitAccessLogIpForSqlServer()
        {
            InitAccessLogIpLocalForSqlServer();
            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<AccessLogEntity> models = dbContext.AccessLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();

            List<string> IpLst = models.Select(m => m.IPAddress).Distinct().ToList();
            if (IpLst != null && IpLst.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (string IpAddress in IpLst)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(IpAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(IpAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(AccessLogEntity accessModel)
                                    {
                                        if (accessModel.IPAddress == IpAddress)
                                        {
                                            accessModel.Country = data.country;
                                            accessModel.CountryNo = data.country_id;
                                            accessModel.BigArea = data.area;
                                            accessModel.Isp = data.isp;
                                            accessModel.Province = data.region;
                                            accessModel.City = data.city;
                                            accessModel.Area = data.county;
                                            accessModel.IsProcessIp = true;
                                            dbContext.AccessLogEntitys.Add(accessModel);
                                            dbContext.Entry<AccessLogEntity>(accessModel).State = EntityState.Modified;
                                            dbContext.SaveChanges();
                                        }
                                    });
                                }
                            }
                            else
                            {
                                iLog.WriteLog("InitAccessLogIpForSqlServer：未获取到结果", 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            iLog.WriteLog("InitAccessLogIpForSqlServer：处理异常：" + ex.Message, 1);
                        }
                    }
                    iLog.WriteLog("InitAccessLogIpForSqlServer：当前处理条数：" + num + " 总条数：" + models.Count, 0);
                    num++;
                }
            }
        }
        private void InitRequestLogIpForMySql()
        {
            InitRequestLogLocalForMySql();
            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<RequestLogEntity> models = dbContext.RequestLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();

            List<string> IpLst = models.Select(m => m.IPAddress).Distinct().ToList();
            if (IpLst != null && IpLst.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (string IpAddress in IpLst)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(IpAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(IpAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(RequestLogEntity requestModel)
                                    {
                                        if (requestModel.IPAddress == IpAddress)
                                        {
                                            requestModel.Country = data.country;
                                            requestModel.CountryNo = data.country_id;
                                            requestModel.BigArea = data.area;
                                            requestModel.Isp = data.isp;
                                            requestModel.Province = data.region;
                                            requestModel.City = data.city;
                                            requestModel.Area = data.county;
                                            requestModel.IsProcessIp = true;
                                            dbContext.RequestLogEntitys.Add(requestModel);
                                            dbContext.Entry<RequestLogEntity>(requestModel).State = EntityState.Modified;
                                            dbContext.SaveChanges();
                                        }
                                    });
                                }
                            }
                            else
                            {
                                iLog.WriteLog("InitAccessLogIpForMySql：未获取到结果", 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            iLog.WriteLog("InitRequestLogIpForMySql：处理异常：" + ex.Message, 1);
                        }
                    }
                    iLog.WriteLog("InitRequestLogIpForMySql：当前处理条数：" + num + " 总条数：" + models.Count, 0);
                    num++;
                }
            }
        }
        private void InitRequestLogIpForSqlServer()
        {
            InitRequestLogLocalForSqlServer();
            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<RequestLogEntity> models = dbContext.RequestLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();

            List<string> IpLst = models.Select(m => m.IPAddress).Distinct().ToList();
            if (IpLst != null && IpLst.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (string IpAddress in IpLst)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(IpAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(IpAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(RequestLogEntity requestModel)
                                    {
                                        if (requestModel.IPAddress == IpAddress)
                                        {
                                            requestModel.Country = data.country;
                                            requestModel.CountryNo = data.country_id;
                                            requestModel.BigArea = data.area;
                                            requestModel.Isp = data.isp;
                                            requestModel.Province = data.region;
                                            requestModel.City = data.city;
                                            requestModel.Area = data.county;
                                            requestModel.IsProcessIp = true;
                                            dbContext.RequestLogEntitys.Add(requestModel);
                                            dbContext.Entry<RequestLogEntity>(requestModel).State = EntityState.Modified;
                                            dbContext.SaveChanges();
                                        }
                                    });
                                }
                            }
                            else
                            {
                                iLog.WriteLog("InitAccessLogIpForMySql：未获取到结果", 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            iLog.WriteLog("InitRequestLogIpForMySql：处理异常：" + ex.Message, 1);
                        }
                    }
                    iLog.WriteLog("InitRequestLogIpForMySql：当前处理条数：" + num + " 总条数：" + models.Count, 0);
                    num++;
                }
            }
        }

        private void InitAccessLogIpLocalForMySql()
        {
            string strSql = @"SELECT distinct A.id,A.IPAddress,B.Country,B.CountryNo,B.BigArea,B.Isp,B.Province,B.City,B.Area from (
	                            SELECT A.Id,A.IPAddress from sys_accesslog as A
	                            where IsProcessIp is NULL or IsProcessIp =0
                            )as A
                            left join sys_accesslog as B ON A.ipaddress=b.IPAddress AND B.IsProcessIp=1";

            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<CommonOldLogEntity> models = new List<CommonOldLogEntity>();
            models = dbContext.Database.SqlQuery<CommonOldLogEntity>(strSql).ToList<CommonOldLogEntity>();
            if (models != null && models.Count > 0)
            {
                List<string> modelIds = models.Select(m => m.Id).ToList();
                List<AccessLogEntity> modelsT = dbContext.AccessLogEntitys.Where(m => modelIds.Contains(m.Id)).ToList();
                if (modelsT != null && modelsT.Count > 0)
                {
                    foreach (AccessLogEntity model in modelsT)
                    {
                        CommonOldLogEntity modelT = models.Find(m => m.Id == model.Id);
                        if (modelT != null)
                        {
                            model.Country = modelT.Country;
                            model.CountryNo = modelT.CountryNo;
                            model.BigArea = modelT.BigArea;
                            model.Isp = modelT.Isp;
                            model.Province = modelT.Province;
                            model.City = modelT.City;
                            model.Area = modelT.Area;
                            model.IsProcessIp = true;
                            dbContext.AccessLogEntitys.Add(model);
                            dbContext.Entry<AccessLogEntity>(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                    }
                }
            }

        }
        private void InitRequestLogLocalForMySql()
        {
            string strSql = @"SELECT distinct A.id,A.IPAddress,B.Country,B.CountryNo,B.BigArea,B.Isp,B.Province,B.City,B.Area from (
	                            SELECT A.Id,A.IPAddress from sys_requestlog as A
	                            where IsProcessIp is NULL or IsProcessIp =0
                            )as A
                            left join sys_requestlog as B ON A.ipaddress=b.IPAddress AND B.IsProcessIp=1";

            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<CommonOldLogEntity> models = new List<CommonOldLogEntity>();
            models = dbContext.Database.SqlQuery<CommonOldLogEntity>(strSql).ToList<CommonOldLogEntity>();
            if (models != null && models.Count > 0)
            {
                List<string> modelIds = models.Select(m => m.Id).ToList();
                List<RequestLogEntity> modelsT = dbContext.RequestLogEntitys.Where(m => modelIds.Contains(m.Id)).ToList();
                if (modelsT != null && modelsT.Count > 0)
                {
                    foreach (RequestLogEntity model in modelsT)
                    {
                        CommonOldLogEntity modelT = models.Find(m => m.Id == model.Id);
                        if (modelT != null)
                        {
                            model.Country = modelT.Country;
                            model.CountryNo = modelT.CountryNo;
                            model.BigArea = modelT.BigArea;
                            model.Isp = modelT.Isp;
                            model.Province = modelT.Province;
                            model.City = modelT.City;
                            model.Area = modelT.Area;
                            model.IsProcessIp = true;
                            dbContext.RequestLogEntitys.Add(model);
                            dbContext.Entry<RequestLogEntity>(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                    }
                }
            }

        }

        private void InitAccessLogIpLocalForSqlServer()
        {
            string strSql = @"SELECT distinct A.id,A.IPAddress,B.Country,B.CountryNo,B.BigArea,B.Isp,B.Province,B.City,B.Area from (
	                            SELECT A.Id,A.IPAddress from sys_accesslog as A
	                            where IsProcessIp is NULL or IsProcessIp =0
                            )as A
                            left join sys_accesslog as B ON A.ipaddress=b.IPAddress AND B.IsProcessIp=1";

            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<CommonOldLogEntity> models = new List<CommonOldLogEntity>();
            models = dbContext.Database.SqlQuery<CommonOldLogEntity>(strSql).ToList<CommonOldLogEntity>();
            if (models != null && models.Count > 0)
            {
                List<string> modelIds = models.Select(m => m.Id).ToList();
                List<AccessLogEntity> modelsT = dbContext.AccessLogEntitys.Where(m => modelIds.Contains(m.Id)).ToList();
                if (modelsT != null && modelsT.Count > 0)
                {
                    foreach (AccessLogEntity model in modelsT)
                    {
                        CommonOldLogEntity modelT = models.Find(m => m.Id == model.Id);
                        if (modelT != null)
                        {
                            model.Country = modelT.Country;
                            model.CountryNo = modelT.CountryNo;
                            model.BigArea = modelT.BigArea;
                            model.Isp = modelT.Isp;
                            model.Province = modelT.Province;
                            model.City = modelT.City;
                            model.Area = modelT.Area;
                            model.IsProcessIp = true;
                            dbContext.AccessLogEntitys.Add(model);
                            dbContext.Entry<AccessLogEntity>(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                    }
                }
            }

        }
        private void InitRequestLogLocalForSqlServer()
        {
            string strSql = @"SELECT distinct A.id,A.IPAddress,B.Country,B.CountryNo,B.BigArea,B.Isp,B.Province,B.City,B.Area from (
	                            SELECT A.Id,A.IPAddress from sys_requestlog as A
	                            where IsProcessIp is NULL or IsProcessIp =0
                            )as A
                            left join sys_requestlog as B ON A.ipaddress=b.IPAddress AND B.IsProcessIp=1";

            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<CommonOldLogEntity> models = new List<CommonOldLogEntity>();
            models = dbContext.Database.SqlQuery<CommonOldLogEntity>(strSql).ToList<CommonOldLogEntity>();
            if (models != null && models.Count > 0)
            {
                List<string> modelIds = models.Select(m => m.Id).ToList();
                List<RequestLogEntity> modelsT = dbContext.RequestLogEntitys.Where(m => modelIds.Contains(m.Id)).ToList();
                if (modelsT != null && modelsT.Count > 0)
                {
                    foreach (RequestLogEntity model in modelsT)
                    {
                        CommonOldLogEntity modelT = models.Find(m => m.Id == model.Id);
                        if (modelT != null)
                        {
                            model.Country = modelT.Country;
                            model.CountryNo = modelT.CountryNo;
                            model.BigArea = modelT.BigArea;
                            model.Isp = modelT.Isp;
                            model.Province = modelT.Province;
                            model.City = modelT.City;
                            model.Area = modelT.Area;
                            model.IsProcessIp = true;
                            dbContext.RequestLogEntitys.Add(model);
                            dbContext.Entry<RequestLogEntity>(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                    }
                }
            }

        }

        private const String host = "https://dm-81.data.aliyun.com";
        private const String path = "/rest/160601/ip/getIpInfo.json";
        private const String method = "GET";
        private String appcode = ConstUtility.AppCode;

        private ResultIpData GetIpAddress(string Ips)
        {
            ResultIpData resdata = new ResultIpData();
            String querys = "ip=" + Ips + "";
            String bodys = "";
            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream st = httpResponse.GetResponseStream();
                StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
                string strs = reader.ReadToEnd();
                ResultIp resIp = JsonConvert.DeserializeObject<ResultIp>(strs);
                if (resIp.code == 0 && resIp.data != null)
                {
                    resdata = JsonConvert.DeserializeObject<ResultIpData>(resIp.data.ToString());
                }
                else
                {

                    iLog.WriteLog("GetIpAddress：处理异常：" + resIp.data.ToString(), 1);
                }
            }
            else
                if (httpResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    System.Threading.Thread.Sleep(5000);
                }
            return resdata;

        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
