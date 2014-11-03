using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChess
{
    class Knight : Piece
    {
        private static readonly List<Pos2> jumpSequence = 
            new List<Pos2>() { Pos2.N.Cpy().Add(Pos2.NE), 
                               Pos2.SE, 
                               Pos2.S.Cpy().Add(Pos2.S),
                               Pos2.SW,
                               Pos2.W.Cpy().Add(Pos2.W),
                               Pos2.NW,
                               Pos2.N.Cpy().Add(Pos2.N),
                               Pos2.NE };

        public Knight(Color color) : base(PieceType.KNIGHT, color) { }

        override protected HashSet<Pos2> ValidMoves(Board board, Pos2 position)
        {
            HashSet<Pos2> validMoves = new HashSet<Pos2>();

            Pos2 target = position.Cpy();
            foreach (Pos2 move in jumpSequence)
            {
                target.Add(move);
                if (board.Contains(target) && !AllyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }
            }

            return validMoves;
        }
    }
}
