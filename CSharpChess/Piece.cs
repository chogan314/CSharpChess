using System;
using System.Collections.Generic;

namespace CSharpChess
{
    abstract class Piece
    {
        public enum PieceType
        {
            PAWN,
            ROOK,
            KNIGHT,
            BISHOP,
            QUEEN,
            KING,
            NO_PIECE
        }

        public enum Color
        {
            WHITE,
            BLACK
        }

        protected PieceType pieceType;
        protected Color color;
        protected bool hasMoved = false;

        public PieceType MPieceType { get { return pieceType; } }
        public Color MColor { get { return color; } }
        public bool HashMoved { get { return hasMoved; } }

        public Piece(PieceType pieceType, Color color)
        {
            this.pieceType = pieceType;
            this.color = color;
        }

        // Is there a piece at given position?
        protected bool PieceAt(Board board, Pos2 position)
        {
            if (!board.Contains(position))
            {
                return false;
            }

            return board.TileAt(position).MPieceType != PieceType.NO_PIECE;
        }

        // Is there an ally at given position?
        protected bool AllyAt(Board board, Pos2 position)
        {
            if (!board.Contains(position))
            {
                return false;
            }

            if (board.TileAt(position).MPieceType == PieceType.NO_PIECE)
            {
                return false;
            }

            return board.TileAt(position).MPiece.MColor == color;
        }

        // Is there an enemy at given position?
        protected bool EnemyAt(Board board, Pos2 position)
        {
            if (!board.Contains(position))
            {
                return false;
            }

            if (board.TileAt(position).MPieceType == PieceType.NO_PIECE)
            {
                return false;
            }

            return board.TileAt(position).MPiece.MColor != color;
        }

        // Unique to each piece: calculates valid moves
        // -- Does not account for check, castling, en pessant, promotion
        protected abstract HashSet<Pos2> ValidMoves(Board board, Pos2 position);

        public bool Move(Board board, Pos2 position, Pos2 target)
        {
            if (ValidMoves(board, position).Contains(target))
            {
                board.TileAt(target).MPiece = this;
                board.TileAt(position).MPiece = null;
                hasMoved = true;
                return true;
            }

            return false;
        }
    }
}
