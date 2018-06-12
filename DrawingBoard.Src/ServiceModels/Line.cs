namespace DrawingBoard.Src.ServiceModels
{
    class Line:ILine
    {
        public int PointX1 { get; set; }
        public int PointY1 { get; set; }
        public int PointX2 { get; set; }
        public int PointY2 { get; set; }
        public char LineChar { get; set; }

        public Line(char drawChar, int x1, int y1, int x2, int y2)
        {
            PointX1 = x1;
            PointY1 = y1;
            PointX2 = x2;
            PointY2 = y2;
            LineChar = drawChar;
        }
    }
}
