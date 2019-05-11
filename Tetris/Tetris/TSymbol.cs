using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    [Serializable]
    class TSymbol : Shapes
    {




        public TSymbol(Point point)
        {
            color = Color.Purple;
            this.currentPos = point;
            activeCubes[1] = new Cubes(point, Color.Purple);
            activeCubes[0] = new Cubes(new Point(point.X - gridSize, point.Y), Color.Purple);
            activeCubes[2] = new Cubes(new Point(point.X + gridSize, point.Y), Color.Purple);
            activeCubes[3] = new Cubes(new Point(point.X, point.Y - gridSize), Color.Purple);
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
                afterRotate[1] = new Cubes(currentPos, Color.Purple);
                afterRotate[0] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y), Color.Purple);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), Color.Purple);
                afterRotate[3] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), Color.Purple);
            }
            else if (rotation == 1)
            {
                afterRotate[1] = new Cubes(currentPos, Color.Purple);
                afterRotate[0] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), Color.Purple);
                afterRotate[2] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), Color.Purple);
                afterRotate[3] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), Color.Purple);
            }
            else if (rotation == 2)
            {
                afterRotate[1] = new Cubes(currentPos, Color.Purple);
                afterRotate[0] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y), Color.Purple);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y), Color.Purple);
                afterRotate[3] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), Color.Purple);
            }
            else if (rotation == 3)
            {
                afterRotate[1] = new Cubes(currentPos, Color.Purple);
                afterRotate[0] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), Color.Purple);
                afterRotate[2] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), Color.Purple);
                afterRotate[3] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y), Color.Purple);
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
