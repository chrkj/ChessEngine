namespace Chess.Core
{
    public class Move
    {
        public readonly int StartSquare;
        public readonly int TargetSquare;
        public byte Piece;
        
        public Move(int startSquare, int targetSquare, byte piece)
        {
            StartSquare = startSquare;
            TargetSquare = targetSquare;
            Piece = piece;
        }
    }
}