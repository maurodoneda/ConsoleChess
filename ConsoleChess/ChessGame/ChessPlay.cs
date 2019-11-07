using System;
using System.Collections.Generic;
using System.Text;
using ConsoleChess.ChessBoard;


namespace ConsoleChess.ChessGame
{
    class ChessPlay
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void ExecutePlay(Position from , Position to)
        {
            ExecuteMove(from, to);
            Turn++;
            ChangePlayer();

        }

        public void ValidatePositionFrom(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece on the chosen position!");
            }
            if(CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The chosen piece is not your to play!");
            }
            if (!Board.Piece(pos).IsPossibleToMove())
            {
                throw new BoardException("There is no posible moves for this piece!");
            }
        }


        public void ValidatePositionTo(Position from, Position to)
        {
            if (!Board.Piece(from).PossibleToMoveTo(to))
            {
                throw new BoardException("You can't move this piece to this position!");
            }
        }


        private void ChangePlayer()
        {
            if ( CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPiece()
        {
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('c', 1).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('d', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('e', 2).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('h', 7).ToPosition());
            Board.PutPiece(new King(Color.Black, Board), new ChessBoardPosition('b', 5).ToPosition());
            Board.PutPiece(new King(Color.White, Board), new ChessBoardPosition('d', 1).ToPosition());
            Board.PutPiece(new Tower(Color.White, Board), new ChessBoardPosition('e', 1).ToPosition());
            
        }

    }
}
