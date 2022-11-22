using System.Numerics;
using SFML.Graphics;

namespace RenderSFML.Logic
{
    struct Vertex
    {
        public Vector3 position;
        public Color color;
        public Vertex(Vector3 position, Color color)
        {
            this.position = position;
            this.color = color;
        }
        public Vertex(Vector3 position)
        {
            this.position = position;
            this.color = Color.White;
        }
        public override string ToString()
        {
            return position.ToString();
        }
    }
}
