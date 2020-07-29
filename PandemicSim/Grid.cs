using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PandemicSim
{
    /// <summary>
    /// The simlation grid.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The grid's tiles
        /// </summary>
        private readonly Tile[][] tiles;

        /// <summary>
        /// Creates a new instance of <see cref="Grid"/>.
        /// </summary>
        /// <param name="size">The size of the grid. Grid actual size
        /// is size x size</param>
        public Grid(int size)
        {
            tiles = new Tile[size][];

            for (int i = 0; i < size; i++)
            {
                tiles[i] = new Tile[size];

                for (int k = 0; k < size; k++)
                {
                    tiles[i][k] = new Tile(i, k);
                }
            }
        }

        /// <summary>
        /// Place an <see cref="Agent"/> at a given location on the grid.
        /// </summary>
        /// <param name="agent">The <see cref="Agent"/> to place.</param>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        public void PlaceAgent(Agent agent, int row, int column)
        {
            Tile tile = tiles[row][column];

            if (agent.TileRef != null)
            {
                agent.TileRef.MoveAgentOut(agent);
            }

            agent.SetTile(tile);

            tile.MoveAgentIn(agent);
        }

        /// <summary>
        /// Performs a random movement in the <see cref="Agent"/>'s Moore 
        /// Neighborhood.
        /// </summary>
        /// <param name="rng"></param>
        /// <param name="agent"></param>
        public void RandomlyMoveAgent(Random rng, Agent agent)
        {
            MooreNeighborhood[] availableMoves;
            MooreNeighborhood move;
            Coord delta, newPos;

            availableMoves = GetAvailableMoves(agent.TileRef);

            move = availableMoves[rng.Next(availableMoves.Length)];

            delta = GetMoveDelta(move);
            newPos = agent.TileRef.Pos + delta;

            PlaceAgent(agent, newPos.Row, newPos.Column);
        }

        /// <summary>
        /// Returns Moore's Neighborhood restricted to the ones available 
        /// from the given <see cref="Tile"/>.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>The moves available from the given <see cref="Tile"/>
        /// </returns>
        private MooreNeighborhood[] GetAvailableMoves(Tile tile)
        {   
            List<MooreNeighborhood> allMoves, allowedMoves;

            allMoves = Enum.GetValues(typeof(MooreNeighborhood))
                        .Cast<MooreNeighborhood>()
                        .ToList();

            allowedMoves = new List<MooreNeighborhood>();

            for (int i = 0; i < allMoves.Count; i++)
            {
                if (GetIsMoveAllowed(tile, allMoves[i]))
                {
                    allowedMoves.Add(allMoves[i]);
                }
            }

            return allowedMoves.ToArray();
        }

        /// <summary>
        /// Checks if the resulting position of the move would be inside 
        /// the grid.
        /// </summary>
        /// <param name="tile">The tile from which the move would start.</param>
        /// <param name="direction">The direction of the move.</param>
        /// <returns>Answer to the question: is move allowed?</returns>
        private bool GetIsMoveAllowed(Tile tile, MooreNeighborhood direction)
        {
            Coord delta = GetMoveDelta(direction);
            Coord newPos = tile.Pos + delta;

            if (newPos.Row < 0 || newPos.Column < 0 || 
                newPos.Row >= tiles.Length || newPos.Column >= tiles[0].Length)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// From a given direction, return the respective delta move.
        /// </summary>
        /// <param name="direction">The direction of the move.</param>
        /// <returns><see cref="Coord"/> with the delta to perform 
        /// the move.</returns>
        private Coord GetMoveDelta(MooreNeighborhood direction)
        {
            Coord delta;

            switch (direction)
            {
                case MooreNeighborhood.North:
                    delta = new Coord(-1, 0);
                    break;
                case MooreNeighborhood.NorthEast:
                    delta = new Coord(-1, 1);
                    break;
                case MooreNeighborhood.East:
                    delta = new Coord(0, 1);
                    break;
                case MooreNeighborhood.SouthEast:
                    delta = new Coord(1, 1);
                    break;
                case MooreNeighborhood.South:
                    delta = new Coord(1, 0);
                    break;
                case MooreNeighborhood.SouthWest:
                    delta = new Coord(1, -1);
                    break;
                case MooreNeighborhood.West:
                    delta = new Coord(0, -1);
                    break;
                case MooreNeighborhood.NorthWest:
                    delta = new Coord(-1, -1);
                    break;
                default:
                    delta = new Coord(0, 0);
                    break;
            }

            return delta;
        }
    }
}
