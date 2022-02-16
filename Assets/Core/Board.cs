using UnityEditor;

namespace Chess.Core
{
    public class Board
    {
        // TODO: Should be private and accessed through MakeMove method.
        private readonly byte[] _board = new byte[64];

        private bool _isWhiteToMove = true;
        private int _colorToMove = Piece.White;

        // *******************************************************
        // BOARD -- Board Array. Used to hold the current position 
        // of the board during play. The board itself looks like: 
        // 	05 03 04 06 01 04 03 05
        // 	02 02 02 02 02 02 02 02
        // 	00 00 00 00 00 00 00 00
        // 	00 00 00 00 00 00 00 00
        // 	00 00 00 00 00 00 00 60
        // 	00 00 00 00 00 00 00 00
        // 	34 34 34 34 34 34 34 34
        // 	37 35 36 38 33 36 35 37
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
            _board[0] = Piece.Rook | Piece.White;
            _board[1] = Piece.Knight | Piece.White;
            _board[2] = Piece.Bishop | Piece.White;
            _board[3] = Piece.Queen | Piece.White;
            _board[4] = Piece.King | Piece.White;
            _board[5] = Piece.Bishop | Piece.White;
            _board[6] = Piece.Knight | Piece.White;
            _board[7] = Piece.Rook | Piece.White;
            _board[8] = Piece.Pawn | Piece.White;
            _board[9] = Piece.Pawn | Piece.White;
            _board[10] = Piece.Pawn | Piece.White;
            _board[11] = Piece.Pawn | Piece.White;
            _board[12] = Piece.Pawn | Piece.White;
            _board[13] = Piece.Pawn | Piece.White;
            _board[14] = Piece.Pawn | Piece.White;
            _board[15] = Piece.Pawn | Piece.White;
            
            _board[48] = Piece.Pawn | Piece.Black;
            _board[49] = Piece.Pawn | Piece.Black;
            _board[50] = Piece.Pawn | Piece.Black;
            _board[51] = Piece.Pawn | Piece.Black;
            _board[52] = Piece.Pawn | Piece.Black;
            _board[53] = Piece.Pawn | Piece.Black;
            _board[54] = Piece.Pawn | Piece.Black;
            _board[55] = Piece.Pawn | Piece.Black;
            _board[56] = Piece.Rook | Piece.Black;
            _board[57] = Piece.Knight | Piece.Black;
            _board[58] = Piece.Bishop | Piece.Black;
            _board[59] = Piece.Queen | Piece.Black;
            _board[60] = Piece.King | Piece.Black;
            _board[61] = Piece.Bishop | Piece.Black;
            _board[62] = Piece.Knight | Piece.Black;
            _board[63] = Piece.Rook | Piece.Black;
        }

        public int GetPiece(int file, int rank)
        {
            return _board[GetBoardIndex(file, rank)];
        }
        
        public byte GetPiece(int index)
        {
            return _board[index];
        }
        
        public bool IsWhiteToMove()
        {
            return _isWhiteToMove;
        }
        
        public bool IsBlackToMove()
        {
            return !_isWhiteToMove;
        }

        public int GetColorToMove()
        {
            return _colorToMove;
        }

        // TODO: Set can castle flag
        public void MakeMove(Move move)
        {
            move.Piece |= Piece.MovedMask;
            _board[move.TargetSquare] = move.Piece;
            _board[move.StartSquare] = Piece.None;
            _isWhiteToMove = !_isWhiteToMove;
            _colorToMove = (_isWhiteToMove) ? Piece.White : Piece.Black;
        }
        
        public static int GetBoardIndex(int file, int rank)
        {
            return rank * 8 + file;
        }

        public bool IsCurrentPlayerPiece(int piece)
        {
            return (_colorToMove & Piece.ColorMask) == (piece & Piece.ColorMask);
        }

    }
}