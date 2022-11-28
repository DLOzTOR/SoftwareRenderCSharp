using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using SFML.Graphics;

namespace SoftwareRender
{
    class renderPoint
    {
        public Vector3 position;
        public Color color;

        public renderPoint(Vector3 position, Color color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
