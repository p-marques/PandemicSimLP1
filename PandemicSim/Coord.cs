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
        /// </summary>
        /// Row of the board
        /// </summary>
        public int Row { get; }

        /// </summary>
        /// Column of the board
        /// </summary>
        public int Column { get; }

        /// </summary>
        /// Constroctor
        /// </summary>
        public Coord(int row, int column)
        {
            Column = column;
            Row = row;
        }

        /// </summary>
        /// operator +
        /// </summary>
        /// /// <param name="a"><see cref="Coord"/> a.</param>
        /// <param name="b"><see cref="Coord"/> b.</param>
        /// <returns>The result of a + b.</returns>
        public static Coord operator +(Coord X, Coord Y) =>
                                new Coord(X.Row + Y.Row, X.Column + Y.Column);
    }
}
