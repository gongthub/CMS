using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Comm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CMS.Application.Comm.Tests
{
    [TestClass()]
    public class LucenceHelpTests
    {
        [TestMethod()]
        public void CreateIndexTest()
        {
            //LucenceHelp.CreateIndex(entity.Id, entity.ShortName);
            LucenceHelp.CreateIndex("03d38cd8-34d8-489f-ac85-0a9c2b4c5dda");
        }

        [TestMethod()]
        public void CreateIndexTest1()
        {
            LucenceHelp.CreateIndex("03d38cd8-34d8-489f-ac85-0a9c2b4c5dda", "canlilong");
        }

        [TestMethod()]
        public void SearchTest()
        {
            LucenceHelp.Search("03d38cd8-34d8-489f-ac85-0a9c2b4c5dda", "名称");
        }

        [TestMethod()]
        public void SearchByShortNameTest()
        {
            LucenceHelp.SearchByShortName("TEST111", "新");
        }

        [TestMethod()]
        public void SearchByShortNameIqTest()
        {
            Assert.Fail();
        }
    }
}
