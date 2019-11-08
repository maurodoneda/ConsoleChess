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
        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }
        public bool Check { get; private set; }


        public ChessMatch()

        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPiece();
        }

        public Piece ExecuteMove(Position from, Position to)
        {
            Piece p = Board.RemovePiece(from);
            p.SumQntMoves();
            Piece capturedPiece = Board.RemovePiece(to);
            Board.PutPiece(p, to);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMove(Position from, Position to, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(to);
            p.SubtractQntMoves();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, to);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.PutPiece(p, from);

        }

        public void ExecutePlay(Position from, Position to)
        {
            Piece capturedPiece = ExecuteMove(from, to);
            if (CheckTest(CurrentPlayer))
            {
                UndoMove(from, to, capturedPiece);
                throw new BoardException("You can't put yourself in Check!");

            }

            if (CheckTest(Oponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckMateTest(Oponent(CurrentPlayer)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }



        }

        public HashSet<Piece> PiecesOffGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
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

        private Color Oponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool CheckTest(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no King " + color + " on the board!");
            }
            foreach (Piece x in PiecesInGame(Oponent(color)))
            {
                bool[,] matrix = x.PossibleMoves();
                if (matrix[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!CheckTest(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] array = x.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (array[i, j])
                        {
                            Position from = x.Position;
                            Position to = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(from, to);
                            bool checkTest = CheckTest(color);
                            UndoMove(from, to, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;

        }

        public void ValidatePositionFrom(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece on the chosen position!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
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
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessBoardPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPiece()
        {

            PutNewPiece('c', 1, new Tower(Color.White, Board));
            PutNewPiece('d', 1, new King(Color.White, Board));
            PutNewPiece('h', 7, new Tower(Color.White, Board));

            PutNewPiece('a', 8, new King(Color.Black, Board));
            PutNewPiece('b', 8, new Tower(Color.Black, Board));




        }

    }
}
