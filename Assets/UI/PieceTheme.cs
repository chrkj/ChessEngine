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
            var pieceSprites = Piece.IsBlack(piece) ? blackPieces : whitePieces;
            {
                switch (Piece.GetType(piece))
                {
                    case Piece.King:
                        return pieceSprites.king;
                    case Piece.Pawn:
                        return pieceSprites.pawn;
                    case Piece.Knight:
                        return pieceSprites.knight;
                    case Piece.Bishop:
                        return pieceSprites.bishop;
                    case Piece.Rook:
                        return pieceSprites.rook;
                    case Piece.Queen:
                        return pieceSprites.queen;
                    default:
                        return null;
                }
            }
        }
        
    }
}