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
            var parser = new ItemParser<char>(c => (char)c);
            var input = Reader.FromString("abc");
            var expected = Success._('a', Reader.FromString("bc"));
            Assert.That(parser.Apply(input), Is.EqualTo(expected));
        }

        [Test]
        public void ItemParserに空を渡すと失敗する()
        {
            var parser = new ItemParser<char>(c => (char)c);
            var input = Reader.FromString("");
            var result = parser.Apply(input).Match(
                (r, rest) => (string)Util.Fail(),
                (m, rest) => m
            );
            var expected = "input is empty.";
            Assert.That(result, Is.EqualTo(expected));
        }
        /*
        [Test, Explicit]
        public void Parser() 
        {
            var input = Reader.FromString("ab");
            var expected = Success._(Tuple.Create('a', 'b'), Reader.FromString(""));
            var a = new ItemParser<char>(c => (char)c);
            var b = new ItemParser<char>(c => (char)c);
            var result = (a + b).Apply(input);
            Assert.That(result, Is.EqualTo(expected));
        }
         */
    }
}
