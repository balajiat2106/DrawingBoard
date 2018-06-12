using System;
using DrawingBoard.Src.ServiceModels;

namespace DrawingBoard.Src.Services
{
    /// <summary>
    /// Responsible for drawing various shapes based on user command
    /// </summary>
    class Canvas
    {
        private readonly DrawingBase _dbase;
        private readonly int _boundaryWidth;
        private readonly int _boundaryHeight;
        public Canvas(int width, int height)
        {
            width += 2;
            height += 2;
            _boundaryWidth = width;
            _boundaryHeight = height;
            
            //DrawingBase class injected
            _dbase = new DrawingBase(_boundaryHeight, _boundaryWidth);
        }

        /// <summary>
        /// Draw canvas boundary
        /// </summary>
        /// <param name="boundaryChrX">Length of canvas</param>
        /// <param name="boundaryChrY">Height of canvas</param>
        public void DrawBoundary(Char boundaryChrX, Char boundaryChrY)
        {
            _dbase.Draw(boundaryChrX, 0, 0, _boundaryWidth - 1, 0);
            _dbase.Draw(boundaryChrX, 0, _boundaryHeight - 1, _boundaryWidth - 1, _boundaryHeight - 1);
            _dbase.Draw(boundaryChrY, 0, 1, 0, _boundaryHeight - 2);
            _dbase.Draw(boundaryChrY, _boundaryWidth - 1, 1, _boundaryWidth - 1, _boundaryHeight - 2);
            _dbase.Render();
        }

        /// <summary>
        /// Draws a line based on co-ordinates
        /// </summary>
        /// <param name="line">Line object</param>
        public void DrawLine(ILine line)
        {
            _dbase.Draw(line.LineChar, line.PointX1, line.PointY1, line.PointX2, line.PointY2);
            _dbase.Render();
        }

        /// <summary>
        /// Using line object, draws a rectangle based on co-ordinates
        /// </summary>
        /// <param name="line">Line object</param>
        public void DrawRectangle(ILine line)
        {
            _dbase.Draw(line.LineChar, line.PointX1, line.PointY1, line.PointX2, line.PointY1);
            _dbase.Draw(line.LineChar, line.PointX1, line.PointY1, line.PointX1, line.PointY2);
            _dbase.Draw(line.LineChar, line.PointX2, line.PointY1, line.PointX2, line.PointY2);
            _dbase.Draw(line.LineChar, line.PointX1, line.PointY2, line.PointX2, line.PointY2);
            _dbase.Render();
        }

        /// <summary>
        /// Fills the canvas based on the co-ordinate values
        /// </summary>
        /// <param name="point">Point object</param>
        public void FillCanvas(IPoint point)
        {
            _dbase.Fill(point.PointChar,point.PointX, point.PointY);
            _dbase.Render();
        }
    }
}
