using ConsoleChess.ChessBoard;


namespace ConsoleChess.ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ThereIsEnemy(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool EmptySpace(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(pos.Line - 1, pos.Column);
                if (Board.ValidPosition(pos) && EmptySpace(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line - 2, pos.Column);
                if (Board.ValidPosition(pos) && EmptySpace(pos) && QntMoves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
                if (Board.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
                if (Board.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(pos.Line + 1, pos.Column);
                if (Board.ValidPosition(pos) && EmptySpace(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line + 2, pos.Column);
                if (Board.ValidPosition(pos) && EmptySpace(pos) && QntMoves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
                if (Board.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
                if (Board.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }

            return matrix;
        }
    }
}
