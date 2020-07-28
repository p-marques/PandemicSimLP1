using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// Class responsible for the simulation run.
    /// </summary>
    public class Simulation
    {
        /// <summary>
        /// The game's options.
        /// </summary>
        private readonly Options gameOptions;

        /// <summary>
        /// Creates a new instance of <see cref="Simulation"/>.
        /// </summary>
        /// <param name="options">The game's options.</param>
        public Simulation(Options options)
        {
            gameOptions = options;
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
