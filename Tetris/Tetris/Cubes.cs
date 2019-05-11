using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    [Serializable]
    class Cubes
    {
        
        public Point point;
        public Color color;
        public bool ghostShape = false;

        public Cubes(Point point, Color color)
        {
            this.point = point;
            this.color = color;
        }
        public void Draw(Graphics g)
        {
            if (ghostShape)
            {
                g.FillRectangle(new SolidBrush(color), point.X, point.Y, Shapes.gridSize, Shapes.gridSize);
                g.FillRectangle(new SolidBrush(Color.Black), point.X+5, point.Y+5, Shapes.gridSize-10, Shapes.gridSize-10);
            }
            else
            {
                g.FillRectangle(new SolidBrush(color), point.X, point.Y, Shapes.gridSize, Shapes.gridSize);
                g.DrawRectangle(new Pen(Color.Black), point.X, point.Y, Shapes.gridSize, Shapes.gridSize);
            }
            
        }
    }
}
