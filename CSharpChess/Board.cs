namespace CSharpChess
{
    class Board
    {
        private int width;
        private int height;
        private Tile[,] tiles;

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    tiles[x, y] = new Tile();
                }
            }
        }

        public Board() : this(8, 8) { }

        public void SetBoard()
        {
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(0, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(1, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(2, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(3, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(4, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(5, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(6, 6));
            PlacePiece(new Pawn(Piece.Color.WHITE), new Pos2(7, 6));
            PlacePiece(new Rook(Piece.Color.WHITE), new Pos2(0, 7));
            PlacePiece(new Rook(Piece.Color.WHITE), new Pos2(7, 7));
            PlacePiece(new Knight(Piece.Color.WHITE), new Pos2(1, 7));
            PlacePiece(new Knight(Piece.Color.WHITE), new Pos2(6, 7));
            PlacePiece(new Bishop(Piece.Color.WHITE), new Pos2(2, 7));
            PlacePiece(new Bishop(Piece.Color.WHITE), new Pos2(5, 7));
            PlacePiece(new Queen(Piece.Color.WHITE), new Pos2(3, 7));
            PlacePiece(new King(Piece.Color.WHITE), new Pos2(4, 7));


            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(0, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(1, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(2, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(3, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(4, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(5, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(6, 1));
            PlacePiece(new Pawn(Piece.Color.BLACK), new Pos2(7, 1));
            PlacePiece(new Rook(Piece.Color.BLACK), new Pos2(0, 0));
            PlacePiece(new Rook(Piece.Color.BLACK), new Pos2(7, 0));
            PlacePiece(new Knight(Piece.Color.BLACK), new Pos2(1, 0));
            PlacePiece(new Knight(Piece.Color.BLACK), new Pos2(6, 0));
            PlacePiece(new Bishop(Piece.Color.BLACK), new Pos2(2, 0));
            PlacePiece(new Bishop(Piece.Color.BLACK), new Pos2(5, 0));
            PlacePiece(new Queen(Piece.Color.BLACK), new Pos2(3, 0));
            PlacePiece(new King(Piece.Color.BLACK), new Pos2(4, 0));
        }

        // Get tile at position
        public Tile TileAt(Pos2 position)
        {
            return tiles[position.X, position.Y];
        }

        // Does contain position?
        public bool Contains(Pos2 position)
        {
            return position.X >= 0 && position.X < height && position.Y >= 0 && position.Y < height;
        }

        // Places a piece at position if tile is unoccupied
        public bool PlacePiece(Piece piece, Pos2 position)
        {
            if (!Contains(position))
            {
                return false;
            }

            if (TileAt(position).MPieceType != Piece.PieceType.NO_PIECE)
            {
                return false;
            }

            TileAt(position).MPiece = piece;
            return true;
        }

        // Attempt to move piece to target position
        public bool Move(Pos2 position, Pos2 target)
        {
            if (!Contains(position) || !Contains(target))
            {
                return false;
            }

            if (TileAt(position).MPieceType == Piece.PieceType.NO_PIECE)
            {
                return false;
            }

            return TileAt(position).MPiece.Move(this, position, target);
        }


    }
}
