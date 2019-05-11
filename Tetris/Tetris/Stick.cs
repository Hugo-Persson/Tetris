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
    class Stick : Shapes
    {



        
        public Stick(Point point)
        {
            color = Color.Cyan;
            this.currentPos = point;
            activeCubes[0] = new Cubes(new Point(currentPos.X,currentPos.Y-gridSize), color);
            activeCubes[1] = new Cubes(new Point(currentPos.X-gridSize, currentPos.Y -gridSize), color);
            activeCubes[2] = new Cubes(new Point(currentPos.X+gridSize, currentPos.Y-gridSize), color);
            activeCubes[3] = new Cubes(new Point(currentPos.X+gridSize*2, currentPos.Y-gridSize), color);
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
            
            if (rotation == 1 || rotation == 3)
            {
                afterRotate[0] = new Cubes(currentPos, color);
                afterRotate[1] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X, currentPos.Y + gridSize*2 ), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), color);
            }
            if (rotation == 4 || rotation == 2)
            {

                afterRotate[0] = new Cubes(new Point(currentPos.X, currentPos.Y - gridSize), color);
                afterRotate[1] = new Cubes(new Point(currentPos.X - gridSize, currentPos.Y - gridSize), color);
                afterRotate[2] = new Cubes(new Point(currentPos.X + gridSize, currentPos.Y - gridSize), color);
                afterRotate[3] = new Cubes(new Point(currentPos.X + gridSize * 2, currentPos.Y - gridSize), color);
            }
            if (RotationCheck())
            {
                activeCubes = afterRotate;
                rotation++;

                if (rotation == 5)
                {
                    rotation = 1;
                }
                

            }
        }






    }
}
