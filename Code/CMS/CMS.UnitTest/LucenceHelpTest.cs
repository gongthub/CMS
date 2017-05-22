using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.Application.Comm;

namespace CMS.UnitTest
{
    [TestClass]
    public class LucenceHelpTest
    {
        [TestMethod]
        public void CreateIndex()
        {
            LucenceHelp.CreateIndex("03d38cd8-34d8-489f-ac85-0a9c2b4c5dda");
        }
        [TestMethod]
        public void Search()
        {
            LucenceHelp.Search("03d38cd8-34d8-489f-ac85-0a9c2b4c5dda", "名称");
        }
    }
}
