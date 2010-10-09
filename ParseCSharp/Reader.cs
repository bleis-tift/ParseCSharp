using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public class Reader<T>
    {
        private int pos;
        private T[] content;

        public Reader(params T[] content)
        {
            this.content = content;
            this.pos = 0;
        }

        public T Pop()
        {
            return content[pos++];
        }
    }
}
