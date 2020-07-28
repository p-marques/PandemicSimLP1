using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// Struct to store game options. Also responsible for parsing arguments.
    /// </summary>
    public struct Options
    {
        /// <summary>
        /// A list with the mandatory arguments
        /// </summary>
        private static readonly IList<string> mandatoryArgs;

        /// <summary>
        /// A list with the optional arguments
        /// </summary>
        private static readonly IList<string> optionalArgs;

        /// <summary>
        /// Messages to be displayed if the user asks for help.
        /// </summary>
        public static string[] HelpMessages { get; }

        /// <summary>
        /// The size of the map. MapSize x MapSize
        /// </summary>
        public int MapSize { get; private set; }

        /// <summary>
        /// The number of agents at the start of the simulation
        /// </summary>
        public int AgentInitialCount { get; private set; }

        /// <summary>
        /// The number of turns after which an infected agent will die
        /// </summary>
        public int InfectedLifeSpan { get; private set; }

        /// <summary>
        /// The turn number at which the first infection happens
        /// </summary>
        public int FirstInfectionTurn { get; private set; }

        /// <summary>
        /// The max number of turns
        /// </summary>
        public int MaxTurns { get; private set; }

        /// <summary>
        /// Flag indicating if the simulation should be visualized
        /// </summary>
        public bool ShowSimulation { get; private set; }

        /// <summary>
        /// Flag indicating if the results should be saved in a file
        /// </summary>
        public bool OutputSimulationToFile { get; private set; }

        /// <summary>
        /// The name of the file with the results of the simulation
        /// </summary>
        public string OutputFileName { get; private set; }

        /// <summary>
        /// The result of the parser.
        /// </summary>
        public OptionsParserResult ParserResult { get; private set; }

        /// <summary>
        /// A collection of error messages describing any errors found 
        /// during parsing.
        /// </summary>
        public IList<string> ErrorMessages { get; private set; }

        static Options()
        {
            mandatoryArgs = new List<string>() { "-n", "-m", "-l", "-tinf", "-t" };
            optionalArgs = new List<string>() { "-v", "-o" };

            HelpMessages = new string[7]
            {
                "-N: map size. Usage: -N <value>",
                "-M: number of agents in the simulation. Usage: -M <value>",
                "-L: infected agent lifespan. Usage: -L <value>",
                "-Tinf: turn number of first infection. Usage: -Tinf <value>",
                "-T: max turns. Usage: -T <value>",
                "-v: <optional> visualize simulation.",
                "-o: <optional> save file with simulation stats. Usage: -o <value>"
            };
        }

        public static Options ParseArguments(string[] args)
        {
            Options op = new Options();

            IDictionary<string, int> optionsValues = 
                new Dictionary<string, int>();

            // Case doesn't matter
            args = args.Select(s => s.ToLower()).ToArray();

            // If player asked for help just leave
            if (args.Length == 1 && args.Contains("-h"))
            {
                op.ParserResult = OptionsParserResult.Help;
                return op;
            }

            // For clarity since default value is 0 (Ok)
            op.ParserResult = OptionsParserResult.Ok;

            IList<string> parsedOptions = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (parsedOptions.Contains(args[i]))
                {
                    op.SetErrorState($"Repeated argument: {args[i]}");
                    break;
                }
                else if (mandatoryArgs.Contains(args[i]) || args[i] == optionalArgs[1])
                {
                    parsedOptions.Add(args[i]);

                    // Has vaule pair?
                    if (args.Length > i + 1 && !args[i + 1].StartsWith("-"))
                    {
                        if (args[i] == optionalArgs[1])
                        {
                            op.OutputSimulationToFile = true;
                            op.OutputFileName = args[i + 1];

                            // Jump over value pair
                            i++;
                        }
                        else
                        {
                            // Must be an integer
                            if (int.TryParse(args[i + 1], out int value))
                            {
                                optionsValues[args[i]] = value;

                                // Jump over value pair
                                i++;
                            }
                            else
                            {
                                op.SetErrorState($"{args[i]} value must be an integer");
                            }
                        }
                    }
                    else
                    {
                        op.SetErrorState($"No value provided for argument: {args[i]}");
                    }
                }
                else if (args[i] == optionalArgs[0])
                {
                    parsedOptions.Add(args[i]);

                    op.ShowSimulation = true;
                }
                else
                {
                    op.SetErrorState($"Unknown argument: {args[i]}");
                }
            }

            // Check for missing mandatory arguments
            for (int i = 0; i < mandatoryArgs.Count; i++)
            {
                if (!parsedOptions.Contains(mandatoryArgs[i]))
                {
                    op.SetErrorState($"Argument {mandatoryArgs[i]} is missing");
                }
            }

            // Everything ok
            if (op.ParserResult == OptionsParserResult.Ok)
            {
                op.MapSize = optionsValues[mandatoryArgs[0]];
                op.AgentInitialCount = optionsValues[mandatoryArgs[1]];
                op.InfectedLifeSpan = optionsValues[mandatoryArgs[2]];
                op.FirstInfectionTurn = optionsValues[mandatoryArgs[3]];
                op.MaxTurns = optionsValues[mandatoryArgs[4]];
            }
            
            return op;
        }

        /// <summary>
        /// Internal method to set error state while adding a message.
        /// </summary>
        /// <param name="msg">Message that describes what went wrong.</param>
        private void SetErrorState(string msg)
        {
            ParserResult = OptionsParserResult.Error;

            if (ErrorMessages == null)
            {
                ErrorMessages = new List<string>();
            }

            ErrorMessages.Add(msg);
        }
    }
}
