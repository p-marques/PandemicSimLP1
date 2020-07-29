using System;
using System.Linq;

namespace PandemicSim
{
    /// <summary>
    /// Class responsible for the simulation run.
    /// </summary>
    public class Simulation
    {
        /// <summary>
        /// The Random Number Generator
        /// </summary>
        private readonly Random rng;

        /// <summary>
        /// The simulation's options.
        /// </summary>
        private readonly Options simOptions;

        /// <summary>
        /// The simulation's grid.
        /// </summary>
        private readonly Grid simGrid;

        /// <summary>
        /// The simulation's agents.
        /// </summary>
        private readonly Agent[] agents;

        /// <summary>
        /// Flag indicating if any agent is still alive.
        /// </summary>
        private bool IsAnyAgentAlive => agents.Where(x => x.IsDead == false)
                                              .Count() > 0;

        /// <summary>
        /// Creates a new instance of <see cref="Simulation"/>.
        /// </summary>
        /// <param name="options">The game's options.</param>
        public Simulation(Options options)
        {
            rng = new Random();

            simOptions = options;

            simGrid = new Grid(simOptions.GridSize);

            agents = new Agent[simOptions.AgentInitialCount];

            SetupAgents();
        }

        /// <summary>
        /// The main simulation run loop.
        /// </summary>
        public void Run()
        {
            int roundCounter = 1;

            for (; roundCounter <= simOptions.MaxTurns; roundCounter++)
            {
                // Main loop

                // TODO Check if no more agents are alive
            }
        }

        /// <summary>
        /// Randomly setup all agents on the grid.
        /// </summary>
        private void SetupAgents()
        {
            for (int i = 0; i < agents.Length; i++)
            {
                int row, column;

                agents[i] = new Agent(i);

                row = rng.Next(0, simOptions.GridSize);
                column = rng.Next(0, simOptions.GridSize);

                simGrid.PlaceAgent(agents[i], row, column);
            }
        }
    }
}
