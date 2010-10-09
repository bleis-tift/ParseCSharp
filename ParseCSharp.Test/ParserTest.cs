using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParseCSharp;

namespace ParseCSharp.Test
{
    [TestFixture]
    class ParserTest
    {
        [Test]
        public void 入力を消費せずに指定した結果を返すことができる()
        {
            var parser = new ReturnParser<string>("string");
            var input = Reader.FromString("abc");
            var expected = Success._("string", input);
            Assert.That(parser.Apply(input), Is.EqualTo(expected));
        }

        [Test]
        public void 常に失敗を返す()
        {
            var parser = new FailureParser<string>("string");
            var input = Reader.FromString("abc");
            var expected = Failure._("string", input).Build<string>();
            Assert.That(parser.Apply(input).GetType(), Is.EqualTo(expected.GetType()));
        }
        [Test]
        public void 一文字消費する()
        {
            var parser = new ItemParser<char>();
            var input = Reader.FromString("abc");
            var expected = Success._('a', Reader.FromString("bc"));
            Assert.That(parser.Apply(input), Is.EqualTo(expected));
        }
    }
}
