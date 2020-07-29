using System;

namespace PandemicSim
{
    /// <summary>
    /// Class holding <see cref="Main"/>, the starting point of the
    /// application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The UI Manager. Responsible for keeping the UI updated.
        /// </summary>
        public static UIManager UIManager { get; private set; }

        /// <summary>
        /// Program stating point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            // Handle arguments
            Options options = Options.ParseArguments(args);

            // Player asked for the help messages ?
            if (options.ParserResult == OptionsParserResult.Help)
            {
                Console.WriteLine("Available arguments:");

                for (int i = 0; i < Options.HelpMessages.Length; i++)
                {
                    Console.WriteLine($"\t{Options.HelpMessages[i]}");
                }
            }
            else if (options.ParserResult == OptionsParserResult.Error)
            {
                string errorsTitle;

                // Error or Errors?
                errorsTitle = options.ErrorMessages.Count == 1 ?
                    "Error found:" : "Errors found:";

                Console.WriteLine(errorsTitle);

                for (int i = 0; i < options.ErrorMessages.Count; i++)
                {
                    Console.WriteLine($"\t{options.ErrorMessages[i]}");
                }
            }
            else
            {
                // Create instance of the UI Manager
                UIManager = new UIManager();

                // Creates simulation instance
                Simulation sim = new Simulation(options);

                // Start simulation run
                sim.Run();
            }
        }
    }
}
