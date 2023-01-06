using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;
using SoftwareRender.Logic;
using SoftwareRender.Render;

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

        public RenderWindow Window { get => window;}

        public SFMLWindow(uint width, uint height, string name)
        {
            _width = width;
            _height = height;
            _name = name;
        }
        void Awake()
        {

            var mode = new VideoMode(_width, _height);
            window = new RenderWindow(mode, _name);
            renderTexture = new Texture(_width, _height);
            FrameBuffer = new Color[_width, _height];
            img = new Image(FrameBuffer);
            window.KeyPressed += Window_KeyPressed;
            foreach (var entity in scene.Entityes)
            {
                entity.Start(window);
            }
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
            List<RenderPoint> points = new List<RenderPoint>();
            FrameBuffer = new Color[_width, _height];
            foreach (var entity in scene.Entityes)
            {
                points.AddRange(entity.Render());
            }
            points.AddRange(TextRender.Numbers(new System.Numerics.Vector3(350, 350, 0), "0123456789", Color.White));
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
        public void SetScene(Scene scene) => this.scene = scene;
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