

namespace ConsoleChess.Board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board(int lines, int columns, Piece[,] pieces)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines,columns];
        }
    }
}
