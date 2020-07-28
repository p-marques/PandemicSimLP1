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
        /// Creates a new instance of <see cref="Simulation"/>.
        /// </summary>
        /// <param name="options">The game's options.</param>
        public Simulation(Options options)
        {
            simOptions = options;

            simGrid = new Grid(simOptions.GridSize);
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
