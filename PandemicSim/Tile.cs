using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Flag indicating if any <see cref="Agent"/> in this tile is infected.
        /// </summary>
        public bool IsAnyAgentInfected =>
            Agents.Where(x => x.IsInfected == true && x.IsDead == false)
                  .Count() > 0;

        public bool IsAnyAgentHere => Agents.Where(x => x.IsDead == false)
                                            .Count() > 0;

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

        /// <summary>
        /// Infects every <see cref="Agent"/> in this <see cref="Tile"/>.
        /// </summary>
        /// <param name="round">The current round.</param>
        public void SpreadVirus(int round)
        {
            for (int i = 0; i < Agents.Count; i++)
            {
                Agents[i].Infect(round);
            }
        }

        /// <summary>
        /// Checks if any round 
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public bool GetAgentDiedInRound(int round)
        {
            for (int i = 0; i < Agents.Count; i++)
            {
                if (round == Agents[i].DeathRound)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
