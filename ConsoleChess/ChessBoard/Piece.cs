
namespace ConsoleChess.ChessBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QntMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            QntMoves = 0;
        }


        public void SumQntMoves()
        {
            QntMoves++;
        }   
                 
        public bool IsPossibleToMove()
        {
            bool[,] matrix = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PossibleToMoveTo(Position pos)
        {
            return PossibleMoves()[pos.Line, pos.Column];
        }


        public abstract bool[,] PossibleMoves();
    }

}
