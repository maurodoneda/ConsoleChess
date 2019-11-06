using System;
using ConsoleChess.ChessBoard;
using ConsoleChess.ChessGame;


namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.putPiece(new Tower(Color.Black, board), new Position(0, 0));
                board.putPiece(new Tower(Color.Black, board), new Position(1, 3));
                board.putPiece(new King(Color.White, board), new Position(2, 4));
                board.putPiece(new King(Color.White, board), new Position(3, 5));
                

                Screen.PrintBoard(board);
            }

            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            ChessBoardPosition p = new ChessBoardPosition('c',7);

            Console.WriteLine(p);
            Console.WriteLine(p.toPosition());

            Console.ReadLine();


        }
    }
}
