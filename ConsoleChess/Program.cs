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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(play.Board);
                        Console.WriteLine("Turn: " + play.Turn);
                        Console.WriteLine("Waiting next move: " + play.CurrentPlayer);


                        Console.WriteLine();
                        Console.Write("Move piece From: ");
                        Position from = Screen.ReadChessBoardPosition().ToPosition();
                        play.ValidatePositionFrom(from);

                        bool[,] possibleMoves = play.Board.Piece(from).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(play.Board, possibleMoves);

                        Console.Write("to: ");
                        Position to = Screen.ReadChessBoardPosition().ToPosition();
                        play.ValidatePositionTo(from, to);

                        play.ExecutePlay(from, to);
                    }
                    catch (BoardException error)
                    {
                        Console.WriteLine(error.Message);
                        Console.ReadLine();
                    }

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
