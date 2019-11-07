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
                ChessPlay play = new ChessPlay();

                while (!play.GameOver) 
                {
                    Console.Clear();
                    Screen.PrintBoard(play.Board);

                    Console.WriteLine();
                    Console.Write("Move piece From: ");
                    Position from = Screen.ReadChessBoardPosition().ToPosition();

                    bool[,] possibleMoves = play.Board.Piece(from).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(play.Board, possibleMoves);

                    Console.Write("to: ");
                    Position to = Screen.ReadChessBoardPosition().ToPosition();

                    play.ExecuteMove(from, to);

                }

                Screen.PrintBoard(play.Board);
            }

            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

                      
            Console.ReadLine();


        }
    }
}
