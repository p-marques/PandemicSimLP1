using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PandemicSim
{
    /// <summary>
    /// A struct That holds two variables, this two represent the
    /// position on the board
    /// </summary>
    public struct Coord
    {
        /// <summary>
        /// Row of the grid.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Column of the grid.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="row">The row of the grid.</param>
        /// <param name="column">The column of the grid.</param>
        public Coord(int row, int column)
        {
            Column = column;
            Row = row;
        }

        /// <summary>
        /// Operator +.
        /// </summary>
        /// <param name="X">The <see cref="Coord"/> X.</param>
        /// <param name="Y">The <see cref="Coord"/> Y.</param>
        /// <returns>The result of X + Y.</returns>
        public static Coord operator +(Coord X, Coord Y) =>
                                new Coord(X.Row + Y.Row, X.Column + Y.Column);
    }
}
