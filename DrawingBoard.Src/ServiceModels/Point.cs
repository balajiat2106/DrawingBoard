namespace DrawingBoard.Src.ServiceModels
{
    class Point:IPoint
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public char PointChar { get; set; }

        public Point(char pointChar, int pointX, int pointY)
        {
            PointChar = pointChar;
            PointX = pointX;
            PointY = pointY;
        }
    }
}
