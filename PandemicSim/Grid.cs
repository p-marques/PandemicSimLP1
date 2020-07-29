﻿using System;
using System.Collections;
using System.Collections.Generic;

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

            agent.SetTile(tile);

            tile.MoveAgentIn(agent);
        }
    }
}
