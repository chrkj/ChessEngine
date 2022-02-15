using Chess.Core;
using UnityEngine;

namespace Chess.UI
{
    [CreateAssetMenu (menuName = "Theme/PieceTheme")]
    public class PieceTheme : ScriptableObject
    {
        public PieceSprites whitePieces;
        public PieceSprites blackPieces;
        
        public Sprite GetSprite(int piece)
        {
            if (Piece.IsBlack(piece))
            {
                switch (piece)
                {
                    case Piece.BlackPawn:
                        return blackPieces.pawn;
                    case Piece.BlackRook:
                        return blackPieces.rook;
                    case Piece.BlackKnight:
                        return blackPieces.knight;
                    case Piece.BlackBishop:
                        return blackPieces.bishop;
                    case Piece.BlackQueen:
                        return blackPieces.queen;
                    case Piece.BlackKing:
                        return blackPieces.king;
                    default:
                        return null;
                }
            }
            else
            {
                switch (piece)
                {
                    case Piece.WhitePawn:
                        return whitePieces.pawn;
                    case Piece.WhiteRook:
                        return whitePieces.rook;
                    case Piece.WhiteKnight:
                        return whitePieces.knight;
                    case Piece.WhiteBishop:
                        return whitePieces.bishop;
                    case Piece.WhiteQueen:
                        return whitePieces.queen;
                    case Piece.WhiteKing:
                        return whitePieces.king;
                    default:
                        return null;
                }
            }
        }
        
    }
}