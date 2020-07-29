using System;
using System.Collections.Generic;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// Represents one location on the Grid.
    /// <summary>
    public class Tile
    {
        /// <summary>
        /// The position of the tile on the grid.
        /// <summary>
        public Coord Pos { get; }

        /// <summary>
        /// Represents all agents on this tile.
        /// <summary>
        public IList<Agent> Agents { get; }

        /// <summary>
        /// Creates instance of <see cref="Tile"/>.
        /// </summary>
        /// <param name="row">The row position of the tile on the grid.</param>
        /// <param name="column">The column position of the tile 
        /// on the grid.</param>
        public Tile(int row, int column) 
        {
            Pos = new Coord(row, column);
            Agents = new List<Agent>();
        }

        /// <summary>
        /// Move <see cref="Agent"/> in to this tile.
        /// </summary>
        /// <param name="Agent">The <see cref="Agent"/> to move in.</param>
        public void MoveAgentIn(Agent Agent) 
        {
            this.Agents.Add(Agent);
            Agent.SetTile(this);
        }

        /// <summary>
        /// Move <see cref="Agent"/> out of this tile.
        /// </summary>
        /// <param name="agent">The <see cref="Agent"/> to move out.</param>
        public void MoveAgentOut(Agent agent)
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
