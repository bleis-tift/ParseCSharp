using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public abstract class ParseResult<T, Elem>
    {
        public ParseResult(Reader<Elem> rest)
        {
            Rest = rest;
        }

        public Reader<Elem> Rest { get; private set; }

    }

    public static class Success
    {
        public static Success<S, Elem> _<S, Elem>(S result, Reader<Elem> rest)
        {
            return new Success<S, Elem>(result, rest);
        }
    }

    public class Success<T, Elem> : ParseResult<T, Elem>
    {
        public Success(T result, Reader<Elem> rest)
            : base(rest)
        {
            Result = result;
        }

        public T Result { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Success<T, Elem>;
            if (other == null)
                return false;
            return Result.Equals(other.Result);
        }
    }

    public static class Failure
    {
        public static FailureBuilder<Elem> _<Elem>(string msg, Reader<Elem> rest)
        {
            return new FailureBuilder<Elem>(msg, rest);
        }
    }

    public class FailureBuilder<Elem>
    {
        readonly string msg;
        readonly Reader<Elem> rest;
        internal FailureBuilder(string msg, Reader<Elem> rest)
        {
            this.msg = msg;
            this.rest = rest;
        }
        public Failure<T, Elem> Build<T>()
        {
            return new Failure<T, Elem>(msg, rest);
        }
    }

    public class Failure<T, Elem> : ParseResult<T, Elem>
    {
        public Failure(string msg, Reader<Elem> rest)
            : base(rest)
        {
            Result = msg;
        }
        public string Result { get; private set; }
    }
}
