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
    class Square : Shapes
    {
        
        
        

        public Square(Point point)
        {
            this.currentPos = point;
            activeCubes[0] = new Cubes(point, Color.Yellow);
            activeCubes[1] = new Cubes(new Point(point.X + gridSize, point.Y), Color.Yellow);
            activeCubes[2] = new Cubes(new Point(point.X, point.Y - gridSize), Color.Yellow);
            activeCubes[3] = new Cubes(new Point(point.X + gridSize, point.Y - gridSize), Color.Yellow);
        }

        public override void Draw(Graphics g)
        {
            

            foreach(Cubes i in activeCubes)
            {
                i.Draw(g);
                
            }
        }
        public override void Rotate()
        {

            rotation++;
            if (rotation == 5)
            {
                rotation = 1;
            }
            
        }






    }
}
