using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tetris
{
    [Serializable]
    class L2:Shapes
    {
        

        public L2(Point point)
        {
            color = Color.Blue;
            currentPos = point;
            activeCubes[1] = new Cubes(point, color);
            activeCubes[0] = new Cubes(new Point(point.X - gridSize, point.Y), color);
            activeCubes[2] = new Cubes(new Point(point.X + gridSize, point.Y), color);
            activeCubes[3] = new Cubes(new Point(point.X - gridSize, point.Y - gridSize), color);
        }

        public override void Draw(Graphics g)
        {
            
            


            foreach (Cubes i in activeCubes)
            {
                i.Draw(g);

            }
        }
        public override void Rotate()
        {
            afterRotate = new Cubes[4];
            if (rotation == 4)
            {
                afterRotate[1] = new Cubes(currentPos, color);
                afterRotate[0] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y - gridSize), color);
            }
            else if (rotation == 1)
            {
                afterRotate[2] = new Cubes(currentPos, color);
                afterRotate[1] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), color);
                afterRotate[0] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y - gridSize), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), color);
            }
            else if (rotation == 2)
            {
                afterRotate[1] = new Cubes(currentPos, color);
                afterRotate[0] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y + gridSize), color);
            }
            else if (rotation == 3)
            {
                afterRotate[0] = new Cubes(currentPos, color);
                afterRotate[1] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y+gridSize), color);
            }
            if (RotationCheck())
            {
                rotation++;
                if (rotation == 5)
                {
                    rotation = 1;
                }
                activeCubes = afterRotate;

            }
        }
    }
}
