﻿

namespace ConsoleChess.ChessBoard

{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;


        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines,columns];
        }
                

        public Piece Piece(int line, int column)
        {
            return Pieces [line, column];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistentPiece(pos))
            {
                throw new BoardException("There is already a piece in this position!");
            }    
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }


        public Piece RemovePiece(Position pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;


        }


        public bool ExistentPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;                        
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid Position");
            }
        }



    }
}
