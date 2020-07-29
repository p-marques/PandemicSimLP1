using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// Class responsible for managing the user interface.
    /// </summary>
    public class UIManager
    {
        /// <summary>
        /// The console's default background color.
        /// </summary>
        private readonly ConsoleColor defaultBackgroundColor;

        /// <summary>
        /// Creates a new instance of <see cref="UIManager"/>.
        /// </summary>
        public UIManager()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            defaultBackgroundColor = Console.BackgroundColor;
        }

        /// <summary>
        /// Update UI.
        /// </summary>
        /// <param name="roundCounter">Current round.</param>
        /// <param name="currentTurnReport">Current turn report.</param>
        /// <param name="showGrid">Show the grid?</param>
        /// <param name="grid">The <see cref="Grid"/> to show.</param>
        public void Update(int roundCounter,
                           TurnReport currentTurnReport, 
                           bool showGrid, 
                           Grid grid)
        {
            ConsoleKey userInput;

            if (showGrid)
            {
                Console.Clear();
            }

            Console.BackgroundColor = defaultBackgroundColor;

            PrintTurnReport(roundCounter, currentTurnReport);

            if (showGrid)
            {
                ShowGrid(roundCounter, grid);

                Console.WriteLine("Press [Enter] to continue.");

                while (true)
                {
                    userInput = GetUserInputKey();

                    if (userInput == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Print the given round report to the console.
        /// </summary>
        /// <param name="roundCounter">The current round.</param>
        /// <param name="turnReport">The <see cref="TurnReport"/> to show.
        /// </param>
        private void PrintTurnReport(int roundCounter, TurnReport turnReport)
        {
            string holder;

            holder = $"Turn {roundCounter}: ";
            holder += $"{turnReport.Healthy} healthy, ";
            holder += $"{turnReport.Infected} infected ";
            holder += $"and {turnReport.Dead} dead.";

            Console.WriteLine(holder);
        }

        /// <summary>
        /// Display the <see cref="Grid"/> on the console.
        /// </summary>
        /// <param name="roundCounter">The current round.</param>
        /// <param name="grid">The grid to display.</param>
        private void ShowGrid(int roundCounter, Grid grid)
        {
            Tile holder;

            for (int i = 0; i < grid.Tiles.Length; i++)
            {
                for (int k = 0; k < grid.Tiles[i].Length; k++)
                {
                    holder = grid.Tiles[i][k];

                    ShowTile(roundCounter, holder);
                }

                Console.WriteLine();
            }

            Console.BackgroundColor = defaultBackgroundColor;
        }

        /// <summary>
        /// Display the <see cref="Tile"/> on the console.
        /// </summary>
        /// <param name="roundCounter">The current round.</param>
        /// <param name="tile">The <see cref="Tile"/> to display.</param>
        private void ShowTile(int roundCounter, Tile tile)
        {
            if (!tile.IsAnyAgentHere)
            {
                Console.BackgroundColor = defaultBackgroundColor;
            }
            else if (tile.IsAnyAgentInfected)
            {
                if (tile.GetAgentDiedInRound(roundCounter))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }

            Console.Write("  ");
        }

        /// <summary>
        /// Gets user input key.
        /// </summary>
        /// <returns>The key hit by the user.</returns>
        private ConsoleKey GetUserInputKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            return keyInfo.Key;
        }
    }
}
