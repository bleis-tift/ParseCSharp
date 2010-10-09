using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParseCSharp;

namespace ParseCSharp.Test
{
    [TestFixture]
    class ParseResultTest
    {
        [Test]
        public void Successから結果が取り出せる()
        {
            var result = Success._("aaa", default(Reader<char>));
            Assert.That(result.Result, Is.EqualTo("aaa"));
        }

        [TestCase("abc", "abc", true)]
        [TestCase("abc", "abb", false)]
        [TestCase("bbc", "abc", false)]
        public void Successの等値性が分かる(string s1, string s2, bool f)
        {
            var r1 = Success._(s1, default(Reader<char>));
            var r2 = Success._(s2, default(Reader<char>));
            Assert.That(r2.Equals(r1), Is.EqualTo(f));
        }

        [Test]
        public void Failureからメッセージが取り出せる()
        {
            var result = Failure._("error", default(Reader<char>)).Build<string>();
            Assert.That(result.Result, Is.EqualTo("error"));
        }

        [Test]
        public void ParseResultからrestが取り出せる()
        {
            var expected = Reader.FromString("bc");
            var input = Reader.FromString("bc");
            var result = Success._("aaa", input);
            Assert.That(result.Rest, Is.EqualTo(expected));
        }

        [Test]
        public void Successに対応する関数が呼びだされる()
        {
            var input = Reader.FromString("bc");
            var opt = Success._("abc", input);
            var result = opt.Match(
                (r, rest) => r,
                (m, rest) => (string)Util.Fail()
            );
            Assert.That(result, Is.EqualTo("abc"));
        }

        [Test]
        public void Failureに対応する関数が呼び出される()
        {
            var input = Reader.FromString("bc");
            var opt = Failure._("abc", input).Build<string>();
            var result = opt.Match(
                (r, rest) => Util.Fail(),
                (m, rest) => m
            );
            Assert.That(result, Is.EqualTo("abc"));

        }

    }
}
