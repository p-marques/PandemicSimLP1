using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// </summary>
    /// Stores the number of healthy, infected and dead agents
    /// </summary>
    class TurnReport
    {
        public int Healthy { get; }
        public int Infected { get; }
        public int Dead { get; }

        public TurnReport(int healthyNumb, int infectedNumb, int deadNumb) 
        {
            this.Healthy = healthyNumb;
            this.Infected = infectedNumb;
            this.Dead = deadNumb;
        }
    }
}
