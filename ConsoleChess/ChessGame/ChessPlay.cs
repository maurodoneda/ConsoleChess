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
            PutPiece();
        }

        public void ExecuteMove(Position from, Position to)
        {
            Piece p = Board.RemovePiece(from);
            p.SumQntMoves();
            Board.RemovePiece(to);
            Piece capturedPiece = Board.RemovePiece(to);
            Board.PutPiece(p, to);
        }

        private void PutPiece()
        {
            Board.PutPiece(new Tower(Color.Black, Board), new ChessBoardPosition('c', 1).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('d', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('e', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('h', 7).ToPosition());
            Board.PutPiece(new King(Color.Black, Board), new ChessBoardPosition('b', 5).ToPosition());
            
        }

    }
}
