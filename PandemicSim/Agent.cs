using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// This class represent the person on a tile and its states
    /// <summary>
    public class Agent
    {
        /// <summary>
        /// Agent identifier.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The tile where this agent is.
        /// <summary>
        public Tile TileRef { get; private set; }

        /// <summary>
        /// Flag indicating if the Agent is infected.
        /// </summary>
        public bool IsInfected { get; private set; }

        /// <summary>
        /// Flag indicating if the Agent is dead.
        /// </summary>
        public bool IsDead { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Agent"/>.
        /// </summary>
        /// <param name="id">The Agent's identifier.</param>
        public Agent(int id) 
        {
            this.Id = id;
        }

        /// <summary>
        /// Sets the tile of this agent to a new one.
        /// <summary>
        public void SetTile(Tile newTile) 
        {
            this.TileRef = newTile;
        }

    }
}
