using System;
using System.Numerics;
using System.Collections.Generic;
using SFML.Graphics;
using SoftwareRender.Render;

namespace SoftwareRender.Logic
{
    class Entity
    {
        public Vector3 position;
        public Vector3 direction = Vector3.Zero;
        public Model model;

        public Entity(Vector3 position, Model model)
        {
            this.position = position;
            this.model = model;
        }
        public virtual void Start(RenderWindow window)
        {
            
        }
        public virtual void Update()
        {
            position += direction;
        }
        public virtual List<RenderPoint> Render()
        {
            List<RenderPoint> render = new List<RenderPoint>();
            foreach(var poly in model.polygons)
            {
                render.AddRange(Draw.Triangle(poly.triangle[0].position + position, poly.triangle[1].position + position, poly.triangle[2].position + position));
            }
            return render;
        }
    }
}
