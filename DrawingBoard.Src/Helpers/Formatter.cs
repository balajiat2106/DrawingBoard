using System.Linq;
using System.Text.RegularExpressions;

namespace DrawingBoard.Src.Helpers
{
    class Formatter
    {
        /// <summary>
        /// Parses the input string
        /// </summary>
        /// <param name="userInput">Raw input string</param>
        /// <returns>Formatted input</returns>
        public static FormattedInput FormatInput(string userInput)
        {
            string trimmedInput = Regex.Replace(userInput, " {2,}", " ").Trim();
            string[] splittedInputString = trimmedInput.Split(' ');
            string command = splittedInputString[0];
            string[] parameters = splittedInputString.Skip(1).ToArray();

            return new FormattedInput(command,parameters);
        }
    }

    /// <summary>
    /// Responsible for separating command character and other parameters
    /// </summary>
    class FormattedInput
    {
        public string Command { get; set; }
        public string[] ParameterStrings { get; set; }

        public FormattedInput(string command, string[] parameterStrings)
        {
            Command = command;
            ParameterStrings = parameterStrings;
        }
    }
}
