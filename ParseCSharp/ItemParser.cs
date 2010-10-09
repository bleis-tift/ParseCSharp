using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public class ItemParser<T>
    {
        Func<object, T> func;

        public ItemParser(Func<object, T> func)
        {
            this.func = func;
        }

        public ParseResult<T, Elem> Apply<Elem>(Reader<Elem> input)
        {
            return input.Pop().Match<ParseResult<T, Elem>>(
                x => Success._(func(x), input),
                _ => Failure._("input is empty.", input).Build<T>()
            );
        }
    }
}
