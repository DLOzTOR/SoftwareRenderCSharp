﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using SFML.Graphics;

namespace RenderSFML
{
    class Draw
    {

        public static List<renderPoint> Line(Vector3 point0, Vector3 point1)
        {
            bool swap = false;
            int x0 = (int)point0.X, y0 = (int)point0.Y, z0 = (int)point0.Z;
            int x1 = (int)point1.X, y1 = (int)point1.Y, z1 = (int)point1.Z;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
                swap = true;
            }
            if (x0 > x1)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
                (z0, z1) = (z1, z0);
            }
            List<renderPoint> returnImg = new List<renderPoint>();
            int deltaX = x1 - x0;
            int deltaY = y1 - y0;
            int deltaZ = z1 - z0;
            int deltaErrorY = Math.Abs(deltaY) * 2;
            int deltaErrorZ = Math.Abs(deltaZ) * 2;
            int errorY = 0;
            int errorZ = 0;
            int y = y0;
            int z = z0;
            for (int x = x0; x <= x1; x++)
            {
                if (swap)
                {
                    returnImg.Add(new renderPoint(new Vector3(y, x, z), Color.White));
                }
                else
                    returnImg.Add(new renderPoint(new Vector3(x, y, z), Color.White));
                errorY += deltaErrorY;
                errorZ += deltaErrorZ;
                if (errorY > deltaX)
                {
                    y += y1 > y0 ? 1 : -1;
                    errorY -= 2 * deltaX;
                }
                if (errorZ > deltaX)
                {
                    z += z1 > z0 ? 1 : -1;
                    errorZ -= 2 * deltaX;
                }
            };
            return returnImg;
        }
        public static List<renderPoint> Triangle(Vector3 point0, Vector3 point1, Vector3 point2)
        {
            List<renderPoint> firstLine = new List<renderPoint>();
            List<renderPoint> renderTriangle = new List<renderPoint>();
            firstLine.AddRange(Line(point0, point1));
            foreach(var i in firstLine)
            {
                renderTriangle.AddRange(Line(i.position, point2));
            }
            renderTriangle.AddRange(firstLine);
            return renderTriangle;
        }
        public static List<renderPoint> Circule(Vector3 center, int radius, int pointsCount)
        {
            List<Vector3> circulePoints = new List<Vector3>();
            int angle = 360 / pointsCount;
            int curAngle = 0;
            for (int i = 0; i < pointsCount; i++)
            {
                int x = (int)(Math.Cos(curAngle * (Math.PI / 180)) * radius + (int)center.X);
                int y = (int)(Math.Sin(curAngle * (Math.PI / 180)) * radius + (int)center.Y);
                circulePoints.Add(new Vector3(x, y, -255));
                curAngle += angle;
            }
            List<renderPoint> points = new List<renderPoint>();
            for (int i = 0; i < circulePoints.Count - 1; i++)
            {
                points.AddRange(Draw.Triangle(circulePoints[i], circulePoints[i + 1], center));
            }
            points.AddRange(Draw.Triangle(center, circulePoints[circulePoints.Count - 1], circulePoints[0]));
            return points;
        }
        public static List<renderPoint> ZBufferColorize(List<renderPoint> points)
        {
            float min = points.Min(x => x.position.Z);
            float max = points.Max(x => x.position.Z);
            float scale = Math.Abs(max - min);
            foreach (var point in points)
            {
                var value = (Math.Abs(min - point.position.Z) / scale * 255);
                if (value > 255) value = 255;
                byte color = (byte)value;
                point.color = new Color(color, color, color);
            }
            return points;
        }
    }
}