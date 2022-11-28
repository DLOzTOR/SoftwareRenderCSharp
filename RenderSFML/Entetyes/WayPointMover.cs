using System;
using System.Collections.Generic;
using System.Numerics;
using SoftwareRender.Logic;

namespace SoftwareRender.Entetyes
{
    class WayPointMover : Entity
    {
        bool needMove = false;
        List<Vector3> Path;
        Vector3 pointFrom;
        Vector3 pointTo;
        int currentPoint;
        int pathLength;
        float speed= 5;
        public WayPointMover(Vector3 position, Model model, float speed, List<Vector3>Path ) : base(position, model)
        {
            this.Path = Path;
            Start();
            this.speed = speed;
        }
        void Start()
        {
            if (Path.Count > 1)
            {
                needMove = true;
                pathLength = Path.Count;
                currentPoint = 1;
                pointFrom = Path[0];
                pointTo = Path[1];
                CalculateDirection();
            }
        }

        public override void Update()
        {
            if (needMove) {                
                if (Vector3.Distance(position, pointTo) < 2*speed) {
                    position = pointTo;
                    NextPoint();
                }
                Move();
            }
        }
        public void NextPoint()
        {
            if(currentPoint == pathLength - 1)
            {
                currentPoint = 0;
                pointFrom = Path[Path.Count - 1];
                pointTo = Path[0];
            }
            else
            {
                pointFrom = Path[currentPoint];
                currentPoint++;
                pointTo = Path[currentPoint];
            }
            CalculateDirection();
        }
        public void CalculateDirection()
        {
            direction = pointTo - pointFrom;
            direction = Vector3.Normalize(direction);
        }
        public void Move()
        {
            position += direction * speed;
        }
    }
}
