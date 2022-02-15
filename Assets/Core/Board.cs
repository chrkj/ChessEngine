namespace Chess.Core
{
    public class Board
    {
        private byte[] _board = new byte[64];

        // *******************************************************
        // BOARD -- Board Array. Used to hold the current position 
        // of the board during play. The board itself
        // looks like: 
        // 	0402030506030204
        // 	0101010101010101
        // 	0000000000000000
        // 	0000000000000000
        // 	0000000000000060
        // 	0000000000000000
        // 	8181818181818181
        // 	8482838586838284
        // The individual bits of the other bytes in the board array are as follows:
        // 	Bit 5 -- Color of the piece
        // 	    1 -- Black 
        // 	    0 -- White 
        // 	Bit 4 -- Castle flag for Kings only
        // 	Bit 3 -- Piece has moved flag
        // 	Bits 3-1 Piece type 
        // 		1 -- Pawn 
        // 		2 -- Knight
        // 		3 -- Bishop 
        // 		4 -- Rook 
        // 		5 -- Queen 
        // 		6 -- King
        // 		7 -- Not used
        // 		0 -- Empty Square
        // *******************************************************

        public void LoadStartPosition()
        {
            _board[0] = Piece.Rook | Piece.Black;
            _board[1] = Piece.Knight | Piece.Black;
            _board[2] = Piece.Bishop | Piece.Black;
            _board[3] = Piece.Queen | Piece.Black;
            _board[4] = Piece.King | Piece.Black;
            _board[5] = Piece.Bishop | Piece.Black;
            _board[6] = Piece.Knight | Piece.Black;
            _board[7] = Piece.Rook | Piece.Black;
            _board[8] = Piece.Pawn | Piece.Black;
            _board[9] = Piece.Pawn | Piece.Black;
            _board[10] = Piece.Pawn | Piece.Black;
            _board[11] = Piece.Pawn | Piece.Black;
            _board[12] = Piece.Pawn | Piece.Black;
            _board[13] = Piece.Pawn | Piece.Black;
            _board[14] = Piece.Pawn | Piece.Black;
            _board[15] = Piece.Pawn | Piece.Black;
            
            _board[48] = Piece.Pawn | Piece.White;
            _board[49] = Piece.Pawn | Piece.White;
            _board[50] = Piece.Pawn | Piece.White;
            _board[51] = Piece.Pawn | Piece.White;
            _board[52] = Piece.Pawn | Piece.White;
            _board[53] = Piece.Pawn | Piece.White;
            _board[54] = Piece.Pawn | Piece.White;
            _board[55] = Piece.Pawn | Piece.White;
            _board[56] = Piece.Rook | Piece.White;
            _board[57] = Piece.Knight | Piece.White;
            _board[58] = Piece.Bishop | Piece.White;
            _board[59] = Piece.Queen | Piece.White;
            _board[60] = Piece.King | Piece.White;
            _board[61] = Piece.Bishop | Piece.White;
            _board[62] = Piece.Knight | Piece.White;
            _board[63] = Piece.Rook | Piece.White;
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