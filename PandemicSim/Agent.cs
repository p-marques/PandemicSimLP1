using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// this class represent the person on a tile and its states
    /// <summary>
    class Agent
    {
        /// <summary>
        /// the tile where this agent is
        /// <summary>
        public Tile tile;

        public bool isInfected { get; private set; }

        public bool isDead { get; private set; }

        /// <summary>
        /// sets the tile of this agent to a new one
        /// <summary>
        public void setsetTile(Tile newTile) 
        {
            this.tile = newTile;
        }

    }
}
