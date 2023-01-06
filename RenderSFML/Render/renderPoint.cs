using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using SFML.Graphics;

namespace SoftwareRender.Render
{
    class RenderPoint
    {
        public Vector3 position;
        public Color color;

        public RenderPoint(Vector3 position, Color color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
