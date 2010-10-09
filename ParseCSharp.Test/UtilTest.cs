using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ParseCSharp.Test
{
    [TestFixture]
    class UtilTest
    {
        [TestCase(ExpectedException = typeof(Exception))]
        public void Failを呼び出すと例外を投げる()
        {
            Util.Fail();
        }

    }
}
