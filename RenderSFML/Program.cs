using System;
using System.Numerics;
using SFML.Graphics;
using RenderSFML.Logic;
namespace RenderSFML
{
    class Program
    {
        static uint _width = 800, _height=800;

        static void Main(string[] args)
        {
            SFMLWindow window = new SFMLWindow(_width, _height, "Render Window");
            window.Run();
        }
    }
}
