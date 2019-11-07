using System;
using System.Collections.Generic;
using System.Text;
using ConsoleChess.ChessBoard;


namespace ConsoleChess.ChessGame
{
    class ChessPlay
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool GameOver { get; private set; }

        public ChessPlay()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            putPiece();
        }

        public void executeMove(Position from, Position to)
        {
            Piece p = Board.removePiece(from);
            p.sumQntMoves();
            Board.removePiece(to);
            Piece capturedPiece = Board.removePiece(to);
            Board.putPiece(p, to);
        }

        private void putPiece()
        {
            Board.putPiece(new Tower(Color.Black, Board), new ChessBoardPosition('c', 1).toPosition());
            Board.putPiece(new Tower(Color.White, Board), new ChessBoardPosition('c', 2).toPosition());
            Board.putPiece(new Tower(Color.White, Board), new ChessBoardPosition('d', 2).toPosition());
            Board.putPiece(new Tower(Color.White, Board), new ChessBoardPosition('e', 2).toPosition());
            Board.putPiece(new Tower(Color.White, Board), new ChessBoardPosition('h', 7).toPosition());
            Board.putPiece(new King(Color.Black, Board), new ChessBoardPosition('b', 5).toPosition());
            
        }

    }
}
