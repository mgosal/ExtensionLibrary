using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionLibrary;

namespace UnitTests
{
    [TestClass]
    public class FewSeconds
    {
        [TestMethod]
        public void resultBetween3And4_changeme()
        {
            DateTime timeoutTime = DateTime.Now.Add(new TimeSpan(long.MinValue).FewSeconds());
            DateTime started = timeoutTime;
            Thread.Sleep(new TimeSpan(long.MinValue).FewSeconds());
            Console.WriteLine(string.Format("That took {0} long", (DateTime.Now - started).ToString("ss")));
        }



        [TestMethod]
        public void resultBetween3And4()
        {
            DateTime timeoutTime = DateTime.Now.Add(new TimeSpan(long.MinValue).FewSeconds());
            DateTime started = timeoutTime;
            Thread.Sleep(new TimeSpan(long.MinValue).FewSeconds());
            Console.WriteLine(string.Format("That took {0} long", (DateTime.Now - started).ToString("ss")));
        }
    }
}
