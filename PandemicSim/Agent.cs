using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// An agent in the simulation.
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// The lifespan of the agent after being infected.
        /// </summary>
        private readonly int infectedLifespan;

        /// <summary>
        /// The round at which this Agent was infected.
        /// </summary>
        private int infectedRound;

        /// <summary>
        /// Agent identifier.
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// The Agent's current Tile.
        /// </summary>
        public Tile TileRef { get; private set; }

        /// <summary>
        /// Flag indicating if the Agent is infected.
        /// </summary>
        public bool IsInfected => infectedRound > 0;

        /// <summary>
        /// The round number the agent died.
        /// </summary>
        public int DeathRound { get; private set; }

        /// <summary>
        /// Flag indicating if the Agent is dead.
        /// </summary>
        public bool IsDead { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Agent"/>.
        /// </summary>
        /// <param name="id">The Agent's identifier.</param>
        public Agent(int id, int lifespan) 
        {
            infectedRound = 0;

            infectedLifespan = lifespan;

            this.Id = id;
        }

        /// <summary>
        /// Sets the tile of the agent.
        /// </summary>
        /// <param name="newTile">The new <see cref="Tile"/> of the agent.
        /// </param>
        public void SetTile(Tile newTile) 
        {
            this.TileRef = newTile;
        }

        /// <summary>
        /// Infects the agent.
        /// </summary>
        /// <param name="round">The round at which the infection takes place.
        /// </param>
        public void Infect(int round)
        {
            if (!IsInfected)
            {
                infectedRound = round;
            }
        }

        /// <summary>
        /// Performs a tick on infection. Sets IsDead state according to
        /// lifespan after infected.
        /// </summary>
        /// <param name="round">Current round of simulation.</param>
        public void InfectionTick(int round)
        {
            if ((round - infectedRound) >= infectedLifespan)
            {
                IsDead = true;
                DeathRound = round;
            }
        }
    }
}
