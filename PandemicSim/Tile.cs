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
        /// pos contains the coord with the position
        /// <summary>
        public Coord Pos { get; }

        /// <summary>
        /// Represents all agents on this tile
        /// <summary>
        public IList<Agent> Agents { get; }



        /// <summary>
        /// Sets the position of the tile
        public Tile(int row, int column) 
        {
            Pos = new Coord(row, column);
            Agents = new List<Agent>();
        }

        /// <summary>
        /// Moves agents to the tile
        /// <summary>
        public void moveAgentIn(Agent Agent) 
        {
            this.Agents.Add(Agent);
            Agent.SetTile(this);
        }

        /// <summary>
        /// Errases agents from this tile
        /// Goes through every member of the agents array until he 
        /// founds a member with the same id
        /// <summary>
        public void moveAgentOut(Agent agent)
        {
            int indexOf = -1;

            for (int i = 0; i < Agents.Count; i++)
            {
                if (Agents[i].Id == agent.Id)
                {
                    indexOf = i;
                    break;
                }
            }

            if (indexOf >= 0)
                Agents.RemoveAt(indexOf);
        }
    }
}
