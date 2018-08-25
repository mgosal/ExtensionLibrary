using ExtensionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ExtensionLibraryTests
    {
        [TestMethod]
        public void StringToDataTable()
        {
            var s = "a,b,c";
            var dt = s.ToDataTable();
            Assert.IsTrue(dt.Rows.Count == 1);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DirectoryInfoExtension_CreateDirectory_3deep()
        {
            
        }
    }
}
