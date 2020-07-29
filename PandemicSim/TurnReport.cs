using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// The report of a turn.
    /// Holds the total number of Healthy, Infected and Dead agents so far in
    /// the simulation.
    /// </summary>
    public struct TurnReport
    {
        /// <summary>
        /// The number of healthy agents in the simulation.
        /// </summary>
        public int Healthy { get; }
        
        /// <summary>
        /// The number of infected agents in the simulation.
        /// </summary>
        public int Infected { get; }
        
        /// <summary>
        /// The number of dead agents in the simulation.
        /// </summary>
        public int Dead { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="healthyNumb">The number of healthy agents.</param>
        /// <param name="infectedNumb">The number of infected agents.</param>
        /// <param name="deadNumb">The number of dead agents.</param>
        public TurnReport(int healthyNumb, int infectedNumb, int deadNumb) 
        {
            this.Healthy = healthyNumb;
            this.Infected = infectedNumb;
            this.Dead = deadNumb;
        }
    }
}
