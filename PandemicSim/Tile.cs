using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// Represents one location on the Grid
    /// <summary>
    class Tile
    {
        /// <summary>
        /// pos contains the coord cwith the position
        /// <summary>
        public Coord Pos { get; }

        /// <summary>
        /// repersents the corrent agent on this tile
        /// <summary>
        public Agent Agent { get; private set; }

        /// <summary>
        /// bool that verefys if there is a agent in this tile
        /// <summary>
        public bool isOccupied => Agent != null;

        /// <summary>
        /// sets the position of the tile
        public Tile(int row, int column) 
        {
            Pos = new Coord(row, column);
        }

        /// <summary>
        /// moves agents to the tile
        /// <summary>
        public void moveAgentIn(Agent Agent) 
        { 
            if (!isOccupied) 
            {
                this.Agent = Agent;
                Agent.setTile(this);
            }
        }

        /// <summary>
        /// errases agents from this tile
        /// <summary>
        public void moveAgentOut()
        {
            this.Agent = null;
        }
    }
}
