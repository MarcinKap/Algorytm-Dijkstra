using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    class Element
    {
        public int v;
        public int w;
        public Element next;
        public Element() { }
        public Element(int v, int w, Element next)
        {
            this.v = v;
            this.w = w;
            this.next = next;
        }
    }
}
