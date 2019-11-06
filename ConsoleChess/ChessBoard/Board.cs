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
                

        public Piece piece(int line, int column)
        {
            return Pieces [line, column];
        }

        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public void putPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool existentPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;                        
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position");
            }
        }



    }
}
