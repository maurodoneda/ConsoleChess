using ConsoleChess.ChessBoard;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleChess.ChessGame;

namespace ConsoleChess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessBoardPosition ReadChessBoardPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessBoardPosition(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
