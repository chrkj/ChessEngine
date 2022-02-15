namespace Chess.Core
{
    public class Piece
    {
        // *************************************
        // 	Bit 6: Color of the piece
        // 	    1: Black 
        // 	    0: White 
        // 	Bit 5: Castle flag for Kings only
        // 	Bit 4: Piece has moved flag
        // 	Bits 3-1 Piece type: 
        // 		0: None
        // 		1: King 
        // 		2: Pawn
        // 		3: Knight 
        // 		4: Bishop
        // 		5: Rook
        // 		6: Queen
        // 		7: Not used
        // *************************************
        
        public const byte None =   0b000000;
        public const byte King =   0b000001;
        public const byte Pawn =   0b000010;
        public const byte Knight = 0b000011;
        public const byte Bishop = 0b000100;
        public const byte Rook =   0b000101;
        public const byte Queen =  0b000110;
        
        public const byte Black = 0b100000;
        public const byte White = 0b000000;
        
        public const byte TypeMask =   0b000111;
        public const byte MovedMask =  0b001000;
        public const byte CastleMask = 0b010000;
        public const byte ColorMask =  0b100000;
        
        public static bool IsBlack(int piece)
        {
            return (piece & ColorMask) != Black;
        }
        
        public static bool IsWhite(int piece)
        {
            return (piece & ColorMask) == White;
        }

        public static bool HasMoved(int piece)
        {
            return (piece & MovedMask) == MovedMask;
        }
        
        public static bool CanCastle(int piece)
        {
            return (piece & CastleMask) == CastleMask;
        }

        public static int GetType(int piece)
        {
            return (piece & TypeMask);
        }
        
    }
}