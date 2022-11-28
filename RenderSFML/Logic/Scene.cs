using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareRender.Logic
{
    class Scene
    {
        List<Entity> entityes = new List<Entity>();

        public List<Entity> Entityes { get => entityes; }

        public void AddEntety(Entity entity)
        {
            entityes.Add(entity);
        }
    }
}
