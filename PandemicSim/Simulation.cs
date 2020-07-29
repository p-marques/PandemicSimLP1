using System;

namespace PandemicSim
{
    /// <summary>
    /// Class responsible for the simulation run.
    /// </summary>
    public class Simulation
    {
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
        /// Creates a new instance of <see cref="Simulation"/>.
        /// </summary>
        /// <param name="options">The game's options.</param>
        public Simulation(Options options)
        {
            simOptions = options;

            simGrid = new Grid(simOptions.GridSize);

            agents = new Agent[simOptions.AgentInitialCount];

            for (int i = 0; i < agents.Length; i++)
            {
                agents[i] = new Agent(i);
            }
        }

        /// <summary>
        /// The main simulation run loop.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Ready to run!");
        }
    }
}
