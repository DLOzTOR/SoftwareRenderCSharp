using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;
using SoftwareRender.Logic;
using SoftwareRender.Entetyes;
namespace SoftwareRender
{
    class Program
    {
        static uint _width = 800, _height = 800;

        static void Main(string[] args)
        {
            Scene scene = new Scene();
            scene.AddEntety(new WayPointMover(new Vector3(0, 0, 0), Model.Cube, 5, new List<Vector3> { new Vector3(0, 0, 0), new Vector3(0, 700, 0), new Vector3(700, 700, 0), new Vector3(700, 0, 0) }));
            scene.AddEntety(new WayPointMover(new Vector3(0, 700, 0), Model.Cube, 5, new List<Vector3> { new Vector3(0, 700, 0), new Vector3(700, 700, 0), new Vector3(700, 0, 0), new Vector3(0, 0, 0) }));
            scene.AddEntety(new WayPointMover(new Vector3(700, 700, 0), Model.Cube, 5, new List<Vector3> { new Vector3(700, 700, 0), new Vector3(700, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 700, 0) }));
            scene.AddEntety(new WayPointMover(new Vector3(700, 0, 0), Model.Cube, 5, new List<Vector3> { new Vector3(700, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 700, 0), new Vector3(700, 700, 0), }));
            scene.AddEntety(new ControlledEntity(new Vector3(350, 350, 0), Model.Cube));
            SFMLWindow window = new SFMLWindow(_width, _height, "Render Window");
            window.SetScene(scene);
            window.Run();
        }
    }
}
