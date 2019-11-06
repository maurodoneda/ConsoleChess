﻿using System;
using ConsoleChess.ChessBoard;
using ConsoleChess.ChessGame;


namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.putPiece(new Tower(Color.Black, board), new Position(0, 0));
            board.putPiece(new Tower(Color.Black, board), new Position(1, 3));
            board.putPiece(new King(Color.Black, board), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}
