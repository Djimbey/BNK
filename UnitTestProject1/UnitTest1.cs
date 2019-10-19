using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params["p1"] = "v1";
            Params["p2"] = "v2";
            Dictionary<string, string> Params2 = new Dictionary<string, string>();
            Params2["p1"] = "v1";
            Params2["p2"] = "v2";
            Params2["newnum"] = "v3";

            var form = new BNK.FormAdd();
            string result1 = form.fillcmd(Params,-1);
            string result2 = form.fillcmd(Params, 1);
            string result3 = form.fillcmd(Params2, 1);

            Assert.AreEqual("insert into bnkseek (p1,p2) values (v1,v2);",result1);
            Assert.AreEqual("", result2);
            Assert.AreEqual("update bnkseek set [p1]='v1',[p2]='v2' where [newnum]='v3';", result3);
        }
    }
}
