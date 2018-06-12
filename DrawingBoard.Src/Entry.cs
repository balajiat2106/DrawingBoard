using System;
using DrawingBoard.Src.Constants;
using DrawingBoard.Src.Helpers;

namespace DrawingBoard.Src
{
    public class Entry
    {
        static void Main()
        {
            while (true) //Loops forever until an explicit exit
            {
                string userInput = Console.ReadLine();
                var result = Submain(userInput);
                Console.Write(result); 
            }
        }

        /// <summary>
        /// This method is separated from the main testability
        /// </summary>
        /// <param name="userInput">Raw user input</param>
        /// <returns>Message to the user: Error message, if any. Else, null or emplty string</returns>
        public static string Submain(string userInput)
        {
            if ((!string.IsNullOrEmpty(userInput)) && (!userInput.ToUpper().Equals("Q")))
            {
                if (userInput.ToUpper().Equals("HELP"))
                {
                    return Messages.Help;
                }
                var formattedInput = Formatter.FormatInput(userInput);
                string userCommand = formattedInput.Command;
                //Let this be string, so that we can have multiple character combinations as command (For future purpose)

                string[] userParameters = formattedInput.ParameterStrings;
                return Commander.InvokeCommand(userCommand, userParameters);
            }
            Environment.Exit(0);
            return null;
        }
    }
}
