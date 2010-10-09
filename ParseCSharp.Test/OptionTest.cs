using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParseCSharp;

namespace ParseCSharp.Test
{
    [TestFixture]
    class OptionTest
    {
        [Test]
        public void Someが生成できる()
        {
            var result = Some._("aaa");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Some<string>)));
        }

        [Test]
        public void Someから値が取り出せる()
        {
            var result = Some._("abc");
            Assert.That(result.GetOrElse(""), Is.EqualTo("abc"));
        }

        [Test]
        public void Noneが生成できる()
        {
            var result = None._<string>();
            Assert.That(result.GetType(), Is.EqualTo(typeof(None<string>)));
        }

        [Test]
        public void Noneからデフォルト値が取り出せる()
        {
            var result = None._<string>();
            Assert.That(result.GetOrElse("default"), Is.EqualTo("default"));
        }

        [Test]
        public void Someに対応する関数が呼びだされる()
        {
            var opt = Some._("hoge");
            var result = opt.Match(
                v => v,
                _ => "oops!"
            );
            Assert.That(result, Is.EqualTo("hoge"));
        }

        [Test]
        public void Noneに対応する関数が呼び出される()
        {
            var opt = None._<string>();
            var result = opt.Match(
                _ => "oops!",
                _ => "hoge"
            );
            Assert.That(result, Is.EqualTo("hoge"));
        }
    }
}
