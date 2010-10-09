using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public class Reader<T>
    {
        private int pos;
        private List<T> content;

        public Reader(IEnumerable<T> content)
        {
            this.content = content.ToList<T>();
            this.pos = 0;
        }

        public T Pop()
        {
            return content[pos++];
        }
    }
}
