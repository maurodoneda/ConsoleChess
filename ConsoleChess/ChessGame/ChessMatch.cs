using System;
using System.Collections.Generic;
using System.Text;
using ConsoleChess.ChessBoard;


namespace ConsoleChess.ChessGame
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }

        public HashSet<Piece> Pieces { get; set; }
        public HashSet<Piece> CapturedPieces { get; set; }


        public ChessMatch()
        
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPiece();
        }

        public void ExecuteMove(Position from, Position to)
        {
            Piece p = Board.RemovePiece(from);
            p.SumQntMoves();            
            Piece capturedPiece = Board.RemovePiece(to);           
            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            Board.RemovePiece(to);
            Board.PutPiece(p, to);
        }

        public void ExecutePlay(Position from , Position to)
        {
            ExecuteMove(from, to);
            Turn++;
            ChangePlayer();

        }

        public HashSet<Piece> PiecesOffGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedPieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PiecesOffGame(color));
            return aux;
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

        public void PutNewPiece(char column,int line,Piece piece)
        {
            Board.PutPiece(piece, new ChessBoardPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPiece()
        {

            PutNewPiece('c', 1, new Tower(Color.White, Board));
            PutNewPiece('c', 2, new Tower(Color.White, Board));
            PutNewPiece('d', 2, new Tower(Color.White, Board));
            PutNewPiece('e', 2, new Tower(Color.White, Board));
            PutNewPiece('e', 1, new Tower(Color.White, Board));
            PutNewPiece('d', 1, new King(Color.White, Board));

            PutNewPiece('c', 7, new Tower(Color.Black, Board));
            PutNewPiece('c', 8, new Tower(Color.Black, Board));
            PutNewPiece('d', 7, new Tower(Color.Black, Board));
            PutNewPiece('e', 7, new Tower(Color.Black, Board));
            PutNewPiece('e', 8, new Tower(Color.Black, Board));
            PutNewPiece('d', 8, new King(Color.Black, Board));


            
            
        }

    }
}
