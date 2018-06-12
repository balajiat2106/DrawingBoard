namespace DrawingBoard.Src.ServiceModels
{
    interface ILine
    {
        int PointX1 { get; set; }
        int PointY1 { get; set; }
        int PointX2 { get; set; }
        int PointY2 { get; set; }
        char LineChar { get; set; }
    }
}
