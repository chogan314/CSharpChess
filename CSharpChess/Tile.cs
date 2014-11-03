namespace CSharpChess
{
    class Tile
    {
        private Piece piece;

        public Piece.PieceType MPieceType
        {
            get
            {
                return piece == null ? Piece.PieceType.NO_PIECE : piece.MPieceType;
            }
        }

        public Piece MPiece
        {
            get
            {
                return piece;
            }
            set
            {
                piece = value;
            }
        }
    }
}
