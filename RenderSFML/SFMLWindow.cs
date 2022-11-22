using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using RenderSFML.Logic;
namespace RenderSFML
{
    class SFMLWindow
    {
        uint _width, _height;
        string _name;
        RenderWindow window;
        Sprite sprite;
        Texture renderTexture;
        Image img;
        Scene scene = new Scene();
        static bool InImageSize(int x, int y, uint width, uint heigth) => (x >= 0 && x < width) && (y >= 0 && y < heigth);
        public SFMLWindow(uint width, uint height, string name)
        {
            _width = width;
            _height = height;
            _name = name;
        }
        void Awake()
        {
            scene.AddEntety(new Entity(new Vector3(5, 5, 0), new Model(new List<Logic.Vertex>() { new Logic.Vertex(new Vector3(0, 0, 0)), new Logic.Vertex(new Vector3(0, 100, 0)), new Logic.Vertex(new Vector3(100, 0, 0)), new Logic.Vertex(new Vector3(100, 100, 0)), }, "0 1 2,1 2 3")));
            scene.AddEntety(new Entity(new Vector3(700, 700, 0), new Model(new List<Logic.Vertex>() { new Logic.Vertex(new Vector3(0, 0, 0)), new Logic.Vertex(new Vector3(0, 100, 0)), new Logic.Vertex(new Vector3(100, 0, 0)), new Logic.Vertex(new Vector3(100, 100, 0)), }, "0 1 2,1 2 3")));
            scene.AddEntety(new Entity(new Vector3(700, 5, 0), new Model(new List<Logic.Vertex>() { new Logic.Vertex(new Vector3(0, 0, 0)), new Logic.Vertex(new Vector3(0, 100, 0)), new Logic.Vertex(new Vector3(100, 0, 0)), new Logic.Vertex(new Vector3(100, 100, 0)), }, "0 1 2,1 2 3")));
            scene.AddEntety(new Entity(new Vector3(5, 700, 0), new Model(new List<Logic.Vertex>() { new Logic.Vertex(new Vector3(0, 0, 0)), new Logic.Vertex(new Vector3(0, 100, 0)), new Logic.Vertex(new Vector3(100, 0, 0)), new Logic.Vertex(new Vector3(100, 100, 0)), }, "0 1 2,1 2 3")));
            scene.Entityes[0].direction = new Vector3(1, 0, 0);
            scene.Entityes[1].direction = new Vector3(-1, 0, 0);
            scene.Entityes[2].direction = new Vector3(0, 1, 0);
            scene.Entityes[3].direction = new Vector3(0, -1, 0);
            var mode = new VideoMode(_width, _height);
            window = new RenderWindow(mode, _name);
            renderTexture = new Texture(_width, _height);
            img = new Image(_width, _height);
            window.KeyPressed += Window_KeyPressed;
        }
        void Update()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                foreach (var entity in scene.Entityes)
                {
                    entity.Update();
                }
                Render();
                window.Display();
            }
        }
        public void Run()
        {
            Awake();
            Update();
        }
        private void Render()
        {
            List<renderPoint> points = new List<renderPoint>();
            foreach(var entity in scene.Entityes)
            {
                points.AddRange(entity.Render());
            }
            img = new Image(_width, _height);
            foreach (var point in points)
            {
                if (InImageSize((int)point.position.X, (int)point.position.Y, _width, _height)) img.SetPixel((uint)point.position.X, (uint)point.position.Y, point.color);
            }
            img.FlipVertically();
            renderTexture.Update(img);
            SetSprite(new Sprite(renderTexture));


            if (sprite != null)
            {
                window.Draw(sprite);
            }
        }
        void SetSprite(Sprite sprite) => this.sprite = sprite;
        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}
