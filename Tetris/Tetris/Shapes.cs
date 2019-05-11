using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    [Serializable]
    abstract class Shapes
    {
        public static Point startPos = new Point(500, 43);
        static public int gridSize=35;
        public static int lowestPoint = (gridSize * 19) + 43;
        static public List<Cubes> savedCubes = new List<Cubes>();
        public Point currentPos = startPos;
        public Cubes[] activeCubes = new Cubes[4];

        protected Color color;

        public static int maxLeftPos = startPos.X - gridSize * 4;
        public static int maxRightPos = startPos.X + gridSize * 5;

        public static List<int> indexOfCube = new List<int>();
        public static int clearedRows = 0;
        
        protected Cubes[] afterRotate = new Cubes[4];
        protected int rotation = 1;
        public static int score = 0;
        public static int level = 0;
        /// <summary>
        /// Draws the shape
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// Checks if any rows are filled and then removes those rows and move the other rows down.
        /// </summary>
        public static void ClearRows()
        {
            indexOfCube.Clear();
            int[] rows = new int[20];
            foreach(Cubes i in savedCubes)
            {
                rows[((i.point.Y - startPos.Y) / gridSize)]++;
            }
            for(int i = 0;i<rows.Length;i++)
            {
                //If a row is filled with cubes
                if (rows[i] == 10)
                {
                    
                    for(int n = 0; n<savedCubes.Count; n++)
                    {

                        if (RowNumber(savedCubes[n]) == i)
                        {
                            //I create a list for every cube I want to remove
                            indexOfCube.Add(n);
                        }
                        
                    }
                    
                }
            }
            //I sort the list, I need to do this because I can't remove the indexes otherwise
            for(int i = 0; i < indexOfCube.Count; i++)
            {
                for(int n = 0; n < indexOfCube.Count-1; n++)
                {
                    if (indexOfCube[n + 1] > indexOfCube[n])
                    {
                        int temp = indexOfCube[n];
                        indexOfCube[n] = indexOfCube[n + 1];
                        indexOfCube[n + 1] = temp;
                    }
                }
            }
            List<int> rowsRemoved = new List<int>();
            foreach(int i in indexOfCube)
            {
                bool foundRow = false;
                foreach(int n in rowsRemoved)
                {
                    if (RowNumber(savedCubes[i]) == n)
                    {
                        foundRow = true;
                    }
                }
                if (!foundRow)
                {
                    rowsRemoved.Add(RowNumber(savedCubes[i]));
                }
            }

            int[] allRows = new int[20];
            //I want to know how many grids every row is going to fall
            for(int i = 0; i < allRows.Length; i++)
            {
                for(int n = 0; n < rowsRemoved.Count(); n++)
                {
                    if (i < rowsRemoved[n])
                    {
                        allRows[i]++;
                    }
                }
            }
            
            for(int i = 0; i < savedCubes.Count; i++)
            {
                savedCubes[i].point.Y += gridSize * allRows[RowNumber(savedCubes[i])];
            }

            foreach (int i in indexOfCube)
            {
                savedCubes.RemoveAt(i);
            }
            clearedRows += (indexOfCube.Count / 10);

            int numberOfRemovedRows = indexOfCube.Count / 10;
            int addScore = 0;
            if (numberOfRemovedRows == 1)
            {
                addScore = 40 * (level + 1);
            }
            else if (numberOfRemovedRows == 2)
            {
                addScore = 100 * (level + 1);
            }
            else if (numberOfRemovedRows == 3)
            {
                addScore = 300 * (level + 1);
            }
            else if(numberOfRemovedRows == 4)
            {
                addScore = 1200 * (level + 1);
            }
            score += addScore;
        } //End ClearRows()

        /// <summary>
        /// Return the row of the cube
        /// </summary>
        /// <param name="cube"></param>
        /// <returns></returns>
        public static int RowNumber(Cubes cube)
        {
            return ((cube.point.Y - startPos.Y) / gridSize);
        }
        /// <summary>
        /// Return the column of the cube
        /// </summary>
        /// <param name="cube"></param>
        /// <returns></returns>
        public static int ColumnNumber(Cubes cube)
        {
            return ((cube.point.X-(maxLeftPos-gridSize))/gridSize)-1;
        }
        /// <summary>
        /// Rotates the shape if possible otherwise does nothing
        /// </summary>
        public abstract void Rotate();
        /// <summary>
        /// Checks if the shape can move to the left
        /// </summary>
        /// <returns></returns>
        private bool MoveLeftPrevention()
        {

            foreach (Cubes i in activeCubes)
            {


                if (i != null)
                {
                    if (i.point.X == maxLeftPos)
                    {

                        return false;
                    }
                    foreach (Cubes n in savedCubes)
                    {
                        Point nextTickPos = i.point;
                        nextTickPos.X -= gridSize;
                        if (nextTickPos == n.point)
                        {
                            return false;
                        }
                    }
                }
                
            }
            return true;
        }

        
        /// <summary>
        /// Checks if the shape can move to the left
        /// </summary>
        /// <returns></returns>
        private bool MoveRightPrevention()
        {

            foreach (Cubes i in activeCubes)
            {

                if (i != null)
                {
                    if (i.point.X == maxRightPos)
                    {

                        return false;
                    }
                    foreach (Cubes n in savedCubes)
                    {
                        Point nextTickPos = i.point;
                        nextTickPos.X += gridSize;
                        if (nextTickPos == n.point)
                        {
                            return false;
                        }
                    }
                }
                
            }
            return true;
        }
        /// <summary>
        /// Adds the shape to the savedCubes
        /// </summary>
        public void SaveCubes()
        {
            savedCubes.AddRange(activeCubes);
        }
        /// <summary>
        /// Checks if the shape reached its minimum y position
        /// </summary>
        /// <returns></returns>
        public bool MinimumY()
        {

            for (int i = 0; i < 4; i++)
            {
                if (activeCubes[i].point.Y == lowestPoint)
                {

                    return true;
                }
                for (int n = 0; n < savedCubes.Count; n++)
                {
                    Point nextTickPosition = activeCubes[i].point;
                    nextTickPosition.Y += gridSize;
                    if (nextTickPosition == savedCubes[n].point)
                    {

                        return true;
                    }
                }
            }


            return false;
        }
        /// <summary>
        /// Moves the shape down one grid
        /// </summary>
        public void Fall()
        {
            foreach(Cubes i in activeCubes)
            {
                i.point.Y += gridSize;
            }
            currentPos.Y += gridSize;
        }
        /// <summary>
        /// Moves the shape on grid to the right
        /// </summary>
        public void MoveRight()
        {
            if (MoveRightPrevention())
            {
                foreach (Cubes i in activeCubes)
                {
                    i.point.X += gridSize;
                }
                currentPos.X += gridSize;
            }
            
        }
        /// <summary>
        /// Moves the shape one grid to the left
        /// </summary>
        public void MoveLeft()
        {
            if (MoveLeftPrevention())
            {
                foreach (Cubes i in activeCubes)
                {
                    i.point.X -= gridSize;
                }
                currentPos.X -= gridSize;
            }
            
        }
        /// <summary>
        /// Checks if rotation is possible
        /// </summary>
        /// <returns></returns>
        protected bool RotationCheck()
        {
            foreach (Cubes i in afterRotate)
            {
                
                if (i.point.Y == lowestPoint)
                {

                    return false;
                }
                else if (i.point.X >= maxRightPos+gridSize)
                {

                    return false;
                }
                else if (i.point.X <= maxLeftPos-gridSize)
                {

                    return false;
                }
                foreach (Cubes n in savedCubes)
                {

                    if (i.point == n.point)
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }
        /// <summary>
        /// Toggles between drawing the shape normal or like a ghost shape
        /// </summary>
        public void ToggleGhostShape()
        {
            foreach(Cubes i in activeCubes)
            {
                i.ghostShape = !i.ghostShape;
            }
        }

        
    }
    
}
