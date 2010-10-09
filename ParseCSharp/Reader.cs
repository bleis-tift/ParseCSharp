using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public static class Reader
    {
        public static Reader<char> FromString(string str)
        {
            return new Reader<char>(str.ToCharArray());
        }
    }

    public class Reader<T>
    {
        private int pos;
        private List<T> content;

        public Reader(IEnumerable<T> content)
        {
            this.content = content.ToList<T>();
            this.pos = 0;
        }

        public Option<T> Pop()
        {
            if (pos == content.Count) return None<T>._();

            return Some._<T>(content[pos++]);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Reader<T>;
            if (other == null)
                return false;

            if (pos != other.pos)
                return false;
            if (content.Count != other.content.Count)
                return false;
            return content.Zip(other.content, Tuple.Create).All(t => t.Item1.Equals(t.Item2));
        }
    }
}
