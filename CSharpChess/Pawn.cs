using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChess
{
    class Pawn : Piece
    {
        public Pawn(Color color) : base(PieceType.PAWN, color) { }

        override protected HashSet<Pos2> ValidMoves(Board board, Pos2 position)
        {
            HashSet<Pos2> validMoves = new HashSet<Pos2>();

            if (color == Color.WHITE)
            {
                Pos2 target = position.Cpy().Add(Pos2.N);
                if (board.Contains(target) && !PieceAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Add(Pos2.N);
                if (!hasMoved && board.Contains(target) && !PieceAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Set(position.Cpy().Add(Pos2.NE));
                if (board.Contains(target) && EnemyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Set(position.Cpy().Add(Pos2.NW));
                if (board.Contains(target) && EnemyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }
            }
            else
            {
                Pos2 target = position.Cpy().Add(Pos2.S);
                if (board.Contains(target) && !PieceAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Add(Pos2.S);
                if (!hasMoved && board.Contains(target) && !PieceAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Set(position.Cpy().Add(Pos2.SE));
                if (board.Contains(target) && EnemyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }

                target.Set(position.Cpy().Add(Pos2.SW));
                if (board.Contains(target) && EnemyAt(board, target))
                {
                    validMoves.Add(target.Cpy());
                }
            }

            return validMoves;
        }
    }
}
