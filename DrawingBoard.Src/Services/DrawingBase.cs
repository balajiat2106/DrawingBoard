using System;

namespace DrawingBoard.Src.Services
{
    /// <summary>
    /// Responsible for drawing functionality
    /// </summary>
    class DrawingBase
    {
        protected char[,] DrawingArea;

        protected int BoundaryWidth { get; set; }
        protected int BoundaryHeight { get; set; }

        public DrawingBase(int boundaryWidth, int boundaryHeight)
        {
            BoundaryWidth = boundaryWidth;
            BoundaryHeight = boundaryHeight;
            DrawingArea = new char[BoundaryWidth, BoundaryHeight];
        }

        /// <summary>
        /// Draw a shape based on co-ordinates.
        /// </summary>
        /// <param name="drawChr">Character to be filled for the co-ordinates x1,y1,x2,y2</param>
        /// <param name="x1">Start point x axis</param>
        /// <param name="y1">Start point y axis</param>
        /// <param name="x2">End point x axis</param>
        /// <param name="y2">End point y axis</param>
        public void Draw(char drawChr, int x1, int y1, int x2, int y2)
        {
            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    DrawingArea[i, j] = drawChr;
                }
            }
        }

        /// <summary>
        /// Render the final array as an output
        /// </summary>
        public void Render()
        {
            for (int i = 0; i < BoundaryWidth; i++)
            {
                for (int j = 0; j < BoundaryHeight; j++)
                {
                    Console.Write(DrawingArea[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Fills the bounded area with a character
        /// </summary>
        /// <param name="drawChar">Character to be filled for the co-ordinates x,y</param>
        /// <param name="x">Start point</param>
        /// <param name="y">End point</param>
        public void Fill(char drawChar, int x, int y)
        {
            while (true)
            {
                if (DrawingArea[x, y] != 0)
                {
                    return;
                }

                if (x > 0 || x < BoundaryWidth || y > 0 || y < BoundaryHeight)
                {
                    if (DrawingArea[x, y] == 0)
                        DrawingArea[x, y] = drawChar;
                    Fill(drawChar, x + 1, y);
                    Fill(drawChar, x - 1, y);
                    Fill(drawChar, x, y - 1);
                    y = y + 1;
                    continue;
                }
                break;
            }
        }
    }
}