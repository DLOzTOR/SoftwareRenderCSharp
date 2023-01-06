using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using SFML.Graphics;

namespace SoftwareRender.Render
{
    class TextRender
    {
        static public List<RenderPoint> Numbers(Vector3 bottomLeftRenderPoint ,string numbers, Color color)
        {
            Vector3 pointer = bottomLeftRenderPoint;
            List<RenderPoint> RendenderedNumbers = new List<RenderPoint>();
            foreach (var number in numbers)
            {
                switch (number)
                {
                    case '0':
                        foreach(var vector in Zero) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '1':
                        foreach (var vector in One) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 5;
                        break;
                    case '2':
                        foreach (var vector in Two) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '3':
                        foreach (var vector in Three) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '4':
                        foreach (var vector in Four) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 6;
                        break;
                    case '5':
                        foreach (var vector in Five) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '6':
                        foreach (var vector in Six) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '7':
                        foreach (var vector in Seven) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '8':
                        foreach (var vector in Eight) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    case '9':
                        foreach (var vector in Nine) RendenderedNumbers.Add(new RenderPoint(vector + bottomLeftRenderPoint, color));
                        bottomLeftRenderPoint.X += 7;
                        break;
                    default:
                        break;
                }
            }
            return RendenderedNumbers;
        }
        static Vector3[] Zero = new Vector3[]
        {
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0),
            new Vector3(4,1,0),
            new Vector3(4,2,0),
            new Vector3(4,3,0),
            new Vector3(4,4,0),
            new Vector3(4,5,0),
            new Vector3(3,6,0),
            new Vector3(2,6,0),
            new Vector3(1,6,0),
            new Vector3(0,5,0),
            new Vector3(0,4,0),
            new Vector3(0,3,0),
            new Vector3(0,2,0),
            new Vector3(0,1,0),
        };
        static Vector3[] One = new Vector3[]
        {
            new Vector3(0,4,0),
            new Vector3(1,5,0),
            new Vector3(2,6,0),
            new Vector3(2,5,0),
            new Vector3(2,4,0),
            new Vector3(2,3,0),
            new Vector3(2,2,0),
            new Vector3(2,1,0),
            new Vector3(2,0,0),
        };
        static Vector3[] Two = new Vector3[]
        {
            new Vector3(0,4,0),
            new Vector3(0,5,0),
            new Vector3(1,6,0),
            new Vector3(2,6,0),
            new Vector3(3,6,0),
            new Vector3(4,5,0),
            new Vector3(4,4,0),
            new Vector3(3,3,0),
            new Vector3(2,2,0),
            new Vector3(1,2,0),
            new Vector3(0,1,0),
            new Vector3(0,0,0),
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0),
            new Vector3(4,0,0),
        };
        static Vector3[] Three = new Vector3[]
        {
            new Vector3(0,5,0),
            new Vector3(1,6,0),
            new Vector3(2,6,0),
            new Vector3(3,6,0),
            new Vector3(4,5,0),
            new Vector3(3,4,0),
            new Vector3(2,3,0),
            new Vector3(3,2,0),
            new Vector3(4,1,0),
            new Vector3(3,0,0),
            new Vector3(2,0,0),
            new Vector3(1,0,0),
            new Vector3(0,1,0),
        };
        static Vector3[] Four = new Vector3[]
        {
            new Vector3(0,4,0),
            new Vector3(0,5,0),
            new Vector3(0,6,0),
            new Vector3(3,6,0),
            new Vector3(3,5,0),
            new Vector3(3,4,0),
            new Vector3(3,3,0),
            new Vector3(2,3,0),
            new Vector3(1,3,0),
            new Vector3(0,3,0),
            new Vector3(3,2,0),
            new Vector3(3,1,0),
            new Vector3(3,0,0),
        };
        static Vector3[] Five = new Vector3[]
        {
            new Vector3(4,6,0),
            new Vector3(3,6,0),
            new Vector3(2,6,0),
            new Vector3(1,6,0),
            new Vector3(0,6,0),
            new Vector3(0,5,0),
            new Vector3(0,4,0),
            new Vector3(0,3,0),
            new Vector3(1,3,0),
            new Vector3(2,3,0),
            new Vector3(3,3,0),
            new Vector3(4,2,0),
            new Vector3(4,1,0),
            new Vector3(3,0,0),
            new Vector3(2,0,0),
            new Vector3(1,0,0),
            new Vector3(0,1,0),
        };
        static Vector3[] Six = new Vector3[]
        {
            new Vector3(4,5,0),
            new Vector3(3,6,0),
            new Vector3(2,6,0),
            new Vector3(1,6,0),
            new Vector3(0,5,0),
            new Vector3(0,4,0),
            new Vector3(0,3,0),
            new Vector3(0,2,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0),
            new Vector3(4,1,0),
            new Vector3(4,2,0),
            new Vector3(3,3,0),
            new Vector3(2,3,0),
            new Vector3(1,3,0),
        };
        static Vector3[] Seven = new Vector3[]
        {
            new Vector3(0,6,0),
            new Vector3(1,6,0),
            new Vector3(2,6,0),
            new Vector3(3,6,0),
            new Vector3(4,6,0),
            new Vector3(4,5,0),
            new Vector3(3,4,0),
            new Vector3(3,3,0),
            new Vector3(2,2,0),
            new Vector3(2,1,0),
            new Vector3(2,0,0),
        };
        static Vector3[] Eight = new Vector3[]
        {
            new Vector3(0,4,0),
            new Vector3(0,5,0),
            new Vector3(1,6,0),
            new Vector3(2,6,0),
            new Vector3(3,6,0),
            new Vector3(4,5,0),
            new Vector3(4,4,0),
            new Vector3(3,3,0),
            new Vector3(2,3,0),
            new Vector3(1,3,0),
            new Vector3(0,2,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0),
            new Vector3(4,1,0),
            new Vector3(4,2,0),
        };
        static Vector3[] Nine = new Vector3[]
        {
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0),
            new Vector3(4,1,0),
            new Vector3(4,2,0),
            new Vector3(4,3,0),
            new Vector3(4,4,0),
            new Vector3(4,5,0),
            new Vector3(3,6,0),
            new Vector3(2,6,0),
            new Vector3(1,6,0),
            new Vector3(0,5,0),
            new Vector3(0,4,0),
            new Vector3(1,3,0),
            new Vector3(2,3,0),
            new Vector3(3,3,0),
        };
    }
}
