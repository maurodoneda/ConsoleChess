using ConsoleChess.ChessBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.ChessGame
{
    class ChessBoardPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessBoardPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position toPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }


    }
}
