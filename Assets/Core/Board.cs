namespace Chess.Core
{
    public class Board
    {
        private int[] _board = new int[64];

        public void LoadStartPosition()
        {
            _board[0] = Piece.WhiteRook;
            _board[1] = Piece.WhiteKnight;
            _board[2] = Piece.WhiteBishop;
            _board[3] = Piece.WhiteQueen;
            _board[4] = Piece.WhiteKing;
            _board[5] = Piece.WhiteBishop;
            _board[6] = Piece.WhiteKnight;
            _board[7] = Piece.WhiteRook;
            _board[8] = Piece.WhitePawn;
            _board[9] = Piece.WhitePawn;
            _board[10] = Piece.WhitePawn;
            _board[11] = Piece.WhitePawn;
            _board[12] = Piece.WhitePawn;
            _board[13] = Piece.WhitePawn;
            _board[14] = Piece.WhitePawn;
            _board[15] = Piece.WhitePawn;
            
            _board[48] = Piece.BlackPawn;
            _board[49] = Piece.BlackPawn;
            _board[50] = Piece.BlackPawn;
            _board[51] = Piece.BlackPawn;
            _board[52] = Piece.BlackPawn;
            _board[53] = Piece.BlackPawn;
            _board[54] = Piece.BlackPawn;
            _board[55] = Piece.BlackPawn;
            _board[56] = Piece.BlackRook;
            _board[57] = Piece.BlackKnight;
            _board[58] = Piece.BlackBishop;
            _board[59] = Piece.BlackQueen;
            _board[60] = Piece.BlackKing;
            _board[61] = Piece.BlackBishop;
            _board[62] = Piece.BlackKnight;
            _board[63] = Piece.BlackRook;
        }

        public int GetPiece(int file, int rank)
        {
            return _board[rank * 8 + file];
        }

        public static int GetBoardIndex(int file, int rank)
        {
            return rank * 8 + file;
        }

    }
}