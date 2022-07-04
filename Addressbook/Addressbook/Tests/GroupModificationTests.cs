﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
     public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupDate newData = new GroupDate("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";
            app.Groups.Modify(1, newData);

        }
    }
}
