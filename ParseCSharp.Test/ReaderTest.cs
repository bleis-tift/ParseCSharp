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
        public void stringからReader_char_が作成できる()
        {
            var result = Reader.FromString("abc");
            Assert.That(result, Is.EqualTo(new Reader<char>("abc".ToCharArray())));
        }

        [Test]
        public void 設定した文字列から先頭要素aを取り出せる()
        {
            var reader = Reader.FromString("abc");
            Assert.That(reader.Pop(), Is.EqualTo('a'));
        }

        [Test]
        public void Popを二回呼び出すとbが取り出せる()
        {
            var reader = Reader.FromString("abc");
            reader.Pop();
            Assert.That(reader.Pop(), Is.EqualTo('b'));
        }

        [TestCase("abc", "abc", true)]
        [TestCase("abc", "abcd", false)]
        [TestCase("abc", "ab", false)]
        public void Readerの等値性を判定できる(string str1, string str2, bool expected)
        {
            var r1 = Reader.FromString(str1);
            var r2 = Reader.FromString(str2);

            Assert.That(r1.Equals(r2), Is.EqualTo(expected));
        }

        [Test, Explicit]
        public void Readerが空かどうか判定できる()
        {
            //Assert.That();
        }
    }
}
