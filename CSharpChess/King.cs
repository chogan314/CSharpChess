using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChess
{
    class King : Piece
    {
        private static readonly List<Pos2> directionSequence =
            new List<Pos2>() { Pos2.N, Pos2.E, Pos2.S, Pos2.W,
                               Pos2.NE, Pos2.SE, Pos2.SW, Pos2.NW };

        public King(Color color) : base(PieceType.KING, color) { }

        override protected HashSet<Pos2> ValidMoves(Board board, Pos2 position)
        {
            HashSet<Pos2> validMoves = new HashSet<Pos2>();

            foreach (Pos2 direction in directionSequence)
            {
                Pos2 target = position.Cpy().Add(direction);
                if (board.Contains(target) && !AllyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }
            }

            return validMoves;
        }
    }
}
