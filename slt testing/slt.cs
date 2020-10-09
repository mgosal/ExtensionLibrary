
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace slt_testing
{
    [TestClass]
    public class stl
    {
        [TestMethod]
        public void splitDayTimetablStringByTime()
        {
            string str = @"07:15 BODYPUMP - 45min09:00 HIIT Circuit - 20min(includes gym session)09:15 Indoor Cycling -Coach By Colour10:15 Soft Play Session12:15 Fitness Yoga -45min13:30 Gentle Exercise17:30 HIIT Circuit - 30min17:30 Kettlebell3017:45 Indoor Cycling -Coach By Colour18:00 BODYATTACK18:00 Kettlebell3018:00 ZUMBA18:30 Abs 3019:15 BODYPUMP19:15 Indoor Cycling -Myride Live20:00 Pilates20:15 Aqua Lite21:00 Aqua Lite";
            string[] result = Regex.Matches(str, @"([01]?[0-9]|2[0-3]):[0-5][0-9]").Cast<Match>().Select(m => m.Value).ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Assert.AreEqual(18,result.Count());

        }
    }
}