using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public abstract class Option<T>
    {
        public abstract T GetOrElse(T defaultvalue);
        public abstract S Match<S>(Func<T, S> ifSome, Func<Unit, S> ifNone);
    }

    public static class Some
    {
        public static Some<T> _<T>(T value)
        {
            return new Some<T>(value);
        }
    }

    public class Some<T> : Option<T>
    {
        private T value;

        public Some(T value)
        {
            // TODO: Complete member initialization
            this.value = value;
        }

        public override T GetOrElse(T _)
        {
            return value;
        }

        public override S Match<S>(Func<T, S> ifSome, Func<Unit, S> _)
        {
            return ifSome(value);
        }
    }
    public static class None
    {
        public static None<T> _<T>()
        {
            return None<T>._();
        }
    }

    public class None<T> : Option<T>
    {
        readonly static None<T> instance = new None<T>();
        public static None<T> _()
        {
            return instance;
        }

        private None() { }

        public override T GetOrElse(T defaultvalue)
        {
            return defaultvalue;
        }

        public override S Match<S>(Func<T, S> _, Func<Unit, S> ifNone)
        {
            return ifNone(Unit._);
        }
    }

}
