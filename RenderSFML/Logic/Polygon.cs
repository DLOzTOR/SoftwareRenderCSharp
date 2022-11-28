using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareRender.Logic
{
    class Polygon
    {
        public Vertex[] triangle = new Vertex[3];
        public Polygon(Vertex v0, Vertex v1, Vertex v2)
        {
            triangle[0] = v0;
            triangle[1] = v1;
            triangle[2] = v2;
        }
        public override string ToString()
        {
            return $"|{triangle[0].ToString()} {triangle[1].ToString()} {triangle[2].ToString()}|";
        }
    }
}
