namespace DrawingBoard.Src.Constants
{
    public static class Messages
    {
        //Exceptions
        public const string Exception = "\n\nPlease draw a canvas first\n\n";

        public const string ArgumentException =
            "\n\nSomething went wrong with the command format. Please type \"HELP\" to know more about the allowed commands\n\n";
        public const string IndexOutOfRangeException = "\n\nParameters supplied cannot be plotted inside the canvas boundary or some parameter is missing. Please type \"HELP\" to know more about the allowed commands\n\n";
        public const string FormatException = "\n\nParameter format is incorrect. Please type \"HELP\" to know more about the allowed commands\n\n";

        //Help Message
        public const string Help =
            "\n\nPlease refer below for help\n\n" +
            "Canvas: C width height\n\nLine: L x1 y1 x2 y2 (x1, y1, x2, y2 should be a positive integer)\n\n" +
            "Rectangle: R x1 y1 x2 y2 (x1, y1, x2, y2 should be positive integers)\n\n"+
            "Bucket Fill: B x y c (x and y are positive integers, c can be any alphabet)\n\n"+
            "Clear Canvas: CC\n\nQuit: Q\n\n";

        public const string Success = "\n\nCommand executed successfully\n\n";
    }
}
