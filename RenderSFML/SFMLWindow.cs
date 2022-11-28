using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Numerics;
using SoftwareRender.Logic;
namespace SoftwareRender
{
    class SFMLWindow
    {
        uint _width, _height;
        string _name;
        RenderWindow window;
        Sprite sprite;
        Texture renderTexture;
        Color[,] FrameBuffer;
        Image img;
        Scene scene = new Scene();
        public SFMLWindow(uint width, uint height, string name)
        {
            _width = width;
            _height = height;
            _name = name;
        }
        public void SetScene(Scene scene)
        {
            this.scene = scene;
        }
        void Awake()
        {

            var mode = new VideoMode(_width, _height);
            window = new RenderWindow(mode, _name);
            renderTexture = new Texture(_width, _height);
            FrameBuffer = new Color[_width, _height];
            img = new Image(FrameBuffer);
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
            FrameBuffer = new Color[_width, _height];
            foreach (var entity in scene.Entityes)
            {
                points.AddRange(entity.Render());
            }

            foreach (var point in points)
            {
                if (InImageSize((int)point.position.X, (int)point.position.Y, _width, _height)) FrameBuffer[(uint)point.position.X, (uint)point.position.Y]  = point.color;
            }
            img = new Image(FrameBuffer);
            img.FlipVertically();
            renderTexture.Update(img);
            SetSprite(new Sprite(renderTexture));


            if (sprite != null)
            {
                window.Draw(sprite);
            }
        }
        static bool InImageSize(int x, int y, uint width, uint heigth) => (x >= 0 && x < width) && (y >= 0 && y < heigth);
        void SetSprite(Sprite sprite) => this.sprite = sprite;
        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}
