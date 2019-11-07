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
                    Position from = Screen.ReadChessBoardPosition().toPosition();
                    Console.Write("to: ");
                    Position to = Screen.ReadChessBoardPosition().toPosition();

                    play.executeMove(from, to);
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
