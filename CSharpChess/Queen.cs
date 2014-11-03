using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChess
{
    class Queen : Piece
    {
        private static readonly List<Pos2> directionSequence =
            new List<Pos2>() { Pos2.N, Pos2.E, Pos2.S, Pos2.W,
                               Pos2.NE, Pos2.SE, Pos2.SW, Pos2.NW };

        public Queen(Color color) : base(PieceType.QUEEN, color) { }

        override protected HashSet<Pos2> ValidMoves(Board board, Pos2 position)
        {
            HashSet<Pos2> validMoves = new HashSet<Pos2>();

            foreach (Pos2 direction in directionSequence)
            {
                for (Pos2 target = position.Cpy().Add(direction); board.Contains(target) && !AllyAt(board, target); target.Add(direction))
                {
                    validMoves.Add(target.Cpy());
                    if (EnemyAt(board, target))
                    {
                        break;
                    }
                }
            }

            return validMoves;
        }
    }
}
