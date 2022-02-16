namespace Chess.Core
{
    public class Move
    {
        public readonly byte Piece;
        public readonly int StartSquare;
        public readonly int TargetSquare;
        
        public Move(int startSquare, int targetSquare, byte piece)
        {
            StartSquare = startSquare;
            TargetSquare = targetSquare;
            Piece = piece;
        }

        public override bool Equals(object other)
        {
            if (other is Move move)
                return StartSquare == move.StartSquare && TargetSquare == move.TargetSquare && Piece == move.Piece;
            return false;
        }
        
        public override int GetHashCode()
        {
            return StartSquare.GetHashCode() ^ TargetSquare.GetHashCode() ^ Piece.GetHashCode();
        }
        
    }
}