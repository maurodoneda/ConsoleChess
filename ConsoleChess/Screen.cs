﻿using ConsoleChess.ChessBoard;
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
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }


            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintGamePlay(ChessMatch play)
        {
            PrintBoard(play.Board);
            Console.WriteLine();
            PrintCapturedPieces(play);
            Console.WriteLine();
            Console.WriteLine("Turn: " + play.Turn);

            if (!play.GameOver)
            {
                Console.WriteLine("Waiting next move: " + play.CurrentPlayer);
                if (play.Check)
                {
                    Console.WriteLine("CHECK!!");
                }
            }
            else
            {
                Console.WriteLine("CHECK MATE!!");
                Console.WriteLine("Winner: " + play.CurrentPlayer);
            }
            
        }

        public static void PrintCapturedPieces(ChessMatch play)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintPieceSet(play.PiecesOffGame(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPieceSet(play.PiecesOffGame(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }

        public static void PrintPieceSet(HashSet<Piece> pieceSet)
        {
            Console.Write("[");
            foreach (Piece x in pieceSet)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
       
        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessBoardPosition ReadChessBoardPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessBoardPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");

            }


        }
    }
}

