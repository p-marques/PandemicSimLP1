using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// This class represent the person on a tile and its states
    /// <summary>
    class Agent
    {
        /// <summary>
        /// The tile where this agent is
        /// <summary>
        public Tile TileRef { get; private set; }

        public bool IsInfected { get; private set; }

        public bool IsDead { get; private set; }

        public int Id { get; }

        public Agent(int id) 
        {
            this.Id = id;
        }
        /// <summary>
        /// Sets the tile of this agent to a new one
        /// <summary>
        public void SetTile(Tile newTile) 
        {
            this.TileRef = newTile;
        }

    }
}
