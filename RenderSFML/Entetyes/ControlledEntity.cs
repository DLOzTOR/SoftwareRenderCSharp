using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using SoftwareRender;
using SFML.Window;
using SoftwareRender.Logic;
using SFML.Graphics;

namespace SoftwareRender.Entetyes
{
    class ControlledEntity : Entity
    {
        SFMLWindow window;
        public ControlledEntity(Vector3 position, Model model) : base(position, model)
        {

        }
        public override void Start(RenderWindow window)
        {
            window.KeyPressed += Window_KeyPressed;
        }
        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            var window = (Window)sender;
            if (e.Code == Keyboard.Key.W)
            {
                direction = new Vector3(0, 1, 0);
            }
            if (e.Code == Keyboard.Key.S)
            {
                direction = new Vector3(0, -1, 0);
            }
            if (e.Code == Keyboard.Key.A)
            {
                direction = new Vector3(-1, 0, 0);
            }
            if (e.Code == Keyboard.Key.D)
            {
                direction = new Vector3(1, 0, 0);
            }
            direction *= 3;
        }
    }
}