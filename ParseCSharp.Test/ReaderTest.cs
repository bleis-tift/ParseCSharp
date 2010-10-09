using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParseCSharp;

namespace ParseCSharp.Test
{
    [TestFixture]
    class ReaderTest
    {
        [Test]
        public void 設定した文字列から先頭要素aを取り出せる()
        {
            var reader = new Reader<char>("abc".ToArray());
            Assert.That(reader.Pop(), Is.EqualTo('a'));
        }

        [Test]
        public void Popを二回呼び出すとbが取り出せる()
        {
            var reader = new Reader<char>("abc".ToArray());
            reader.Pop();
            Assert.That(reader.Pop(), Is.EqualTo('b'));
        }
    }
}
