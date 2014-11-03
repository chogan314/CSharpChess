using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.SetBoard();

            Piece.Color turn = Piece.Color.WHITE;

            while(true)
            {
                PrintBoard(board);
                Console.WriteLine("Turn: " + turn.ToString());
                Console.WriteLine("Input move (format: a1 b5):");
                string input = Console.ReadLine();

                if (input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                string[] split = input.Split(new char[] { ' ' });

                if (split.Length != 2)
                {
                    continue;
                }

                Pos2 position = ParsePosition(split[0]);
                Pos2 target = ParsePosition(split[1]);

                if (board.TileAt(position).MPieceType != Piece.PieceType.NO_PIECE &&
                    board.TileAt(position).MPiece.MColor != turn)
                {
                    continue;
                }

                if (board.Move(position, target))
                {
                    if (turn == Piece.Color.WHITE)
                    {
                        turn = Piece.Color.BLACK;
                    }
                    else
                    {
                        turn = Piece.Color.WHITE;
                    }
                }
            }
        }

        static Pos2 ParsePosition(string input)
        {
            input = input.ToLower();
            if (input.Length != 2)
            {
                return new Pos2(-1, -1);
            }

            int xPos = input[0] - 97;
            int yPos = 8 - (input[1] - 48);

            return new Pos2(xPos, yPos);
        }

        static void PrintBoard(Board board)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    Pos2 position = new Pos2(x, y);
                    char symbol = ' ';
                    switch(board.TileAt(position).MPieceType)
                    {
                        case Piece.PieceType.PAWN:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'P' : 'p';
                            break;
                        case Piece.PieceType.ROOK:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'R' : 'r';
                            break;
                        case Piece.PieceType.KNIGHT:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'N' : 'n';
                            break;
                        case Piece.PieceType.BISHOP:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'B' : 'b';
                            break;
                        case Piece.PieceType.QUEEN:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'Q' : 'q';
                            break;
                        case Piece.PieceType.KING:
                            symbol = board.TileAt(position).MPiece.MColor == Piece.Color.WHITE ? 'K' : 'k';
                            break;
                        default:
                            break;
                    }
                    Console.Write("[" + symbol + "]");
                }
                Console.WriteLine();
            }
        }
    }
}
