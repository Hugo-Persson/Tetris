using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    [Serializable]
    class S1 : Shapes
    {

        public S1(Point point)
        {
            this.currentPos = point;
            color = Color.Red;
            activeCubes[1] = new Cubes(point, color);
            activeCubes[0] = new Cubes(new Point(point.X, point.Y + gridSize), color);
            activeCubes[2] = new Cubes(new Point(point.X + gridSize, point.Y), color);
            activeCubes[3] = new Cubes(new Point(point.X + gridSize, point.Y - gridSize), color);
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
            if (rotation == 4 || rotation == 2)
            {
                afterRotate[1] = new Cubes(currentPos, color);
                afterRotate[0] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y - gridSize), color);
            }
            if (rotation == 1 || rotation == 3)
            {
                afterRotate[1] = new Cubes(currentPos, color);
                afterRotate[0] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y - gridSize), color);
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
