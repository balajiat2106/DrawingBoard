using System;
using DrawingBoard.Src.ServiceModels;
using DrawingBoard.Src.Services;

namespace DrawingBoard.Src.Helpers
{
    /// <summary>
    /// Acts as a factory for other services
    /// </summary>
    public class Commander
    {
        private static Canvas _c;
        /// <summary>
        /// Handles user request and performs operations based on it.
        /// </summary>
        /// <param name="userCommand">Command to draw: "c, l, r, b, cc". Upper case or lower case.</param>
        /// <param name="userParameters">Parameters to draw based on selected command. Refer "Constants/ExceptionMessages.cs/Help" variable for more details on parameter format</param>
        /// <returns></returns>
        public static string InvokeCommand(string userCommand, string[] userParameters)
        {
            ExceptionHandler exceptionHandler;
            switch (userCommand.ToUpper())
            {
                case "C":
                    try
                    {
                        int boundaryWidth = Convert.ToInt16(userParameters[0]);
                        int boundaryHeight = Convert.ToInt16(userParameters[1]);

                        if ((boundaryWidth < 1) || (boundaryHeight < 1)) goto ArgExp;

                        _c = new Canvas(boundaryWidth, boundaryHeight);
                        _c.DrawBoundary('-', '|');
                    }
                    catch (IndexOutOfRangeException) { goto IndExp; }
                    catch (FormatException) { goto ForExp; }
                    break;
                case "L":
                    try
                    {
                        int pointX1 = Convert.ToInt16(userParameters[0]);
                        int pointY1 = Convert.ToInt16(userParameters[1]);
                        int pointX2 = Convert.ToInt16(userParameters[2]);
                        int pointY2 = Convert.ToInt16(userParameters[3]);

                        if (pointX1 < 1 || pointY1 < 1 || pointX2 < 1 || pointY2 < 1) goto ArgExp;

                        ILine l = new Line('*', pointX1, pointY1, pointX2, pointY2);
                        if (_c != null) _c.DrawLine(l);
                        else goto Exp;
                    }
                    catch (FormatException) { goto ForExp; }
                    catch (IndexOutOfRangeException) { goto IndExp; }
                    break;
                case "R":
                    try
                    {
                        int pointX1 = Convert.ToInt16(userParameters[0]);
                        int pointY1 = Convert.ToInt16(userParameters[1]);
                        int pointX2 = Convert.ToInt16(userParameters[2]);
                        int pointY2 = Convert.ToInt16(userParameters[3]);

                        if (pointX1 < 1 || pointY1 < 1 || pointX2 < 1 || pointY2 < 1) goto ArgExp;

                        ILine r = new Line('*', pointX1, pointY1, pointX2, pointY2);
                        if (_c != null) _c.DrawRectangle(r);
                        else goto Exp;
                    }
                    catch (IndexOutOfRangeException) { goto IndExp; }
                    catch (FormatException) { goto ForExp; }
                    break;
                case "B":
                    try
                    {
                        int pointX = Convert.ToInt16(userParameters[1]);
                        int pointY = Convert.ToInt16(userParameters[0]);
                        char pointChar = Convert.ToChar(userParameters[2]);

                        if (pointX < 1 || pointY < 1) goto ArgExp;

                        IPoint p = new Point(pointChar, pointX, pointY);
                        if (_c != null) _c.FillCanvas(p);
                        else goto Exp;
                    }
                    catch (FormatException) { goto ForExp; }
                    catch (IndexOutOfRangeException) { goto IndExp; }
                    break;
                case "CC":
                    if (_c != null)
                    {
                       _c = null;
                        return Constants.Messages.Success;
                    }
                    goto Exp;
                default:
                    return Constants.Messages.ArgumentException;
            }
            return string.Empty;

        Exp: exceptionHandler = new ExceptionHandler(Constants.Messages.Exception);
            return exceptionHandler.BaseMessage;

        ArgExp: exceptionHandler = new ExceptionHandler(new ArgumentException(Constants.Messages.ArgumentException));
            return exceptionHandler.BaseMessage;

        ForExp: exceptionHandler = new ExceptionHandler(new FormatException(Constants.Messages.FormatException));
            return exceptionHandler.BaseMessage;

        IndExp: exceptionHandler = new ExceptionHandler(new IndexOutOfRangeException(Constants.Messages.IndexOutOfRangeException));
            return exceptionHandler.BaseMessage;
        }
    }
}
