using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp.Test
{
    public static class Util
    {
        public static object Fail()
        {
            throw new Exception();
            return null;
        }
    }
}
