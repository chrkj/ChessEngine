namespace Chess.Core
{
    public class Piece
    {
        public const int WhiteNone = 0;
        public const int WhiteKing = 1;
        public const int WhitePawn = 2;
        public const int WhiteKnight = 3;
        public const int WhiteBishop = 5;
        public const int WhiteRook = 6;
        public const int WhiteQueen = 7;

        public const int BlackNone = 8;
        public const int BlackKing = 9;
        public const int BlackPawn = 10;
        public const int BlackKnight = 11;
        public const int BlackBishop = 12;
        public const int BlackRook = 13;
        public const int BlackQueen = 14;

        public static bool IsBlack(int piece)
        {
            return piece > 7;
        }
        
        public static bool IsWhite(int piece)
        {
            return piece < 7;
        }
        
    }
}