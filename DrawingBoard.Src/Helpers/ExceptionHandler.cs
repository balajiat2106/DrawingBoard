using System;

namespace DrawingBoard.Src.Helpers
{
    /// <summary>
    /// Special class to handle all exceptions and send out appropriate messages
    /// </summary>
    public class ExceptionHandler : Exception
    {
        private string _localBaseMessage = string.Empty;

        public override string Message
        {
            get
            {
                string baseMessage = base.Message;
                return baseMessage;
            }
        }

        public string BaseMessage
        {
            get { return _localBaseMessage; }
            set { _localBaseMessage = value; }
        }

        public ExceptionHandler(string drawCanvasMessage) :
            base("Something went wrong")
        {
            BaseMessage = drawCanvasMessage;
        }
        public ExceptionHandler(ArgumentException argumentException) :
            base("Something went wrong with the arguments", new ArgumentException())
        {
            BaseMessage = argumentException.Message;
        }

        public ExceptionHandler(IndexOutOfRangeException indexOutOfRangeException) :
            base("Something went wrong with the index range", new IndexOutOfRangeException())
        {
            BaseMessage = indexOutOfRangeException.Message;
        }
        public ExceptionHandler(FormatException formatException) :
            base("Something went wrong with the input parameter format", new FormatException())
        {
            BaseMessage = formatException.Message;
        }
    }
}
