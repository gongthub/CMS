using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Comm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Hosting;
using System.Threading;
namespace CMS.Application.Comm.Tests
{
    [TestClass()]
    public class RequestHelpTests
    {
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/")]
        //[AspNetDevelopmentServerHost("E:\\WorkFiles\\Project\\GIT\\CMS\\Code\\CMS\\CMS.UnitTest", "/")]

        public void InitRequestTest()
        {

            Thread.GetDomain().SetData(".appPath", "E:\\WorkFiles\\Project\\GIT\\CMS\\Code\\CMS\\CMS.Web\\");
            Thread.GetDomain().SetData(".appVPath", "/");
            TextWriter tw = new StringWriter();
            String address = "localhost";
            HttpWorkerRequest wr = new MyWorkerRequest
            ("/", "", tw, address);
            HttpContext.Current = new HttpContext(wr);
            RequestHelp.requestHelp.InitRequest(HttpContext.Current);
        }

        [TestMethod()]
        public void EndRequestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsLoginHostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsContistHostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHostRequestTest()
        {
            Assert.Fail();
        }
        public class MyWorkerRequest : SimpleWorkerRequest
        {
            private string localAdd = string.Empty;

            public MyWorkerRequest(string page, string query, TextWriter output, string address)
                : base(page, query, output)
            {
                this.localAdd = address;
            }

            public override string GetLocalAddress()
            {
                return this.localAdd;
            }
        }
    }
}
