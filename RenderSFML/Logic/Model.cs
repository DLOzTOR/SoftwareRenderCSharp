using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace SoftwareRender.Logic
{
    struct Model
    {
        public List<Vertex> vertexes;
        public List<Polygon> polygons;

        public Model(List<Vertex> vertexes, string setrializedModel)
        {
            this.vertexes = vertexes;
            polygons = new List<Polygon>();
            this.vertexes = vertexes;
            string[] triangles = setrializedModel.Split(',');

            foreach(string triangle in triangles)
            {
                int i = 0;
                int[] indexes = new int[3];
                foreach(var index in triangle.Split(' '))
                {
                    indexes[i] = Convert.ToInt32(index);
                    i++;
                }
                polygons.Add(new Polygon(vertexes[indexes[0]], vertexes[indexes[1]], vertexes[indexes[2]]));
            }
        }
        public override string ToString()
        {
            string vertexStr = "";
            string triangleStr = "";
            foreach (var vertex in vertexes)
            {
                vertexStr += vertex.ToString()+"\n";
            }
            foreach (var triangle in polygons)
            {
                triangleStr += triangle.ToString() +"\n";
            }
            return  triangleStr;
        }
        static public Model Cube = new Model(new List<Logic.Vertex>() { new Logic.Vertex(new Vector3(0, 0, 0)), new Logic.Vertex(new Vector3(0, 100, 0)), new Logic.Vertex(new Vector3(100, 0, 0)), new Logic.Vertex(new Vector3(100, 100, 0)), }, "0 1 2,1 2 3");
    }
    
}
