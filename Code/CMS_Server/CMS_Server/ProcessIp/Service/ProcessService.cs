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
            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<AccessLogEntity> models = dbContext.AccessLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();
            if (models != null && models.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (AccessLogEntity model in models)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(model.IPAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(model.IPAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                model.Country = data.country;
                                model.CountryNo = data.country_id;
                                model.BigArea = data.area;
                                model.Isp = data.isp;
                                model.Province = data.region;
                                model.City = data.city;
                                model.Area = data.county;
                                model.IsProcessIp = true;
                                dbContext.AccessLogEntitys.Add(model);
                                dbContext.Entry<AccessLogEntity>(model).State = EntityState.Modified;
                                dbContext.SaveChanges();
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
            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<AccessLogEntity> models = dbContext.AccessLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();
            if (models != null && models.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (AccessLogEntity model in models)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(model.IPAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(model.IPAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                model.Country = data.country;
                                model.CountryNo = data.country_id;
                                model.BigArea = data.area;
                                model.Isp = data.isp;
                                model.Province = data.region;
                                model.City = data.city;
                                model.Area = data.county;
                                model.IsProcessIp = true;
                                dbContext.AccessLogEntitys.Add(model);
                                dbContext.Entry<AccessLogEntity>(model).State = EntityState.Modified;
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                iLog.WriteLog("InitAccessLogIpForMySql：未获取到结果", 1);
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
            MySqlCMSDbContext dbContext = new MySqlCMSDbContext();
            List<RequestLogEntity> models = dbContext.RequestLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();
            if (models != null && models.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (RequestLogEntity model in models)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(model.IPAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(model.IPAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                model.Country = data.country;
                                model.CountryNo = data.country_id;
                                model.BigArea = data.area;
                                model.Isp = data.isp;
                                model.Province = data.region;
                                model.City = data.city;
                                model.Area = data.county;
                                model.IsProcessIp = true;
                                dbContext.RequestLogEntitys.Add(model);
                                dbContext.Entry<RequestLogEntity>(model).State = EntityState.Modified;
                                dbContext.SaveChanges();
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
            SqlServerCMSDbContext dbContext = new SqlServerCMSDbContext();
            List<RequestLogEntity> models = dbContext.RequestLogEntitys.Where(m => m.IsProcessIp != true && m.IPAddress != "::1").ToList();
            if (models != null && models.Count > 0)
            {
                int num = 1;
                int sTime = 0;
                foreach (RequestLogEntity model in models)
                {
                    sTime++;
                    if (sTime >= 100)
                    {
                        sTime = 0;
                        System.Threading.Thread.Sleep(5000);
                    }
                    if (!string.IsNullOrEmpty(model.IPAddress))
                    {
                        try
                        {
                            ResultIpData data = GetIpAddress(model.IPAddress);
                            if (data != null && !string.IsNullOrEmpty(data.ip))
                            {
                                model.Country = data.country;
                                model.CountryNo = data.country_id;
                                model.BigArea = data.area;
                                model.Isp = data.isp;
                                model.Province = data.region;
                                model.City = data.city;
                                model.Area = data.county;
                                model.IsProcessIp = true;
                                dbContext.RequestLogEntitys.Add(model);
                                dbContext.Entry<RequestLogEntity>(model).State = EntityState.Modified;
                                dbContext.SaveChanges();
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
