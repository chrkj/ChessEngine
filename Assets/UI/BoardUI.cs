using Chess.Core;
using UnityEngine;

namespace Chess.UI
{
    public class BoardUI : MonoBehaviour
    {
        public PieceTheme pieceTheme;
        public float pieceScale = 0.3f;
        public float pieceDepth = -0.1f;
        public Color darkColor = new Color(0.59f, 0.69f, 0.45f);
        public Color lightColor = new Color(0.93f, 0.93f, 0.82f);
        public MeshRenderer[] SquareRenderers { get; private set; }
        public SpriteRenderer[] PieceRenderers { get; private set; }

        private const float BoardOffset = -3.5f;
        
        private readonly char[] _fileChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};

        public void InitBoard()
        {
            SquareRenderers = new MeshRenderer[64];
            PieceRenderers = new SpriteRenderer[64];
            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var color = (file + rank) % 2 == 0 ? lightColor : darkColor;
                    DrawSquare(file, rank, color);
                }
            }
        }

        private void DrawSquare(int file, int rank, Color color)
        {
            // Create square
            var square = GameObject.CreatePrimitive(PrimitiveType.Quad).transform;
            square.parent = transform;
            square.name = _fileChars[file] + (rank + 1).ToString();
            square.position = new Vector3(file + BoardOffset, rank + BoardOffset, 0f);

            var squareMaterial = new Material(Shader.Find("Unlit/Color"));
            squareMaterial.color = color;
            SquareRenderers[Board.GetBoardIndex(file, rank)] = square.gameObject.GetComponent<MeshRenderer>();
            SquareRenderers[Board.GetBoardIndex(file, rank)].material = squareMaterial;

            // Create piece sprite renderer for current square
            var pieceRenderer = new GameObject("Piece").AddComponent<SpriteRenderer>();
            var pieceRendererTc = pieceRenderer.transform;
            pieceRendererTc.parent = square;
            pieceRendererTc.position = new Vector3(file + BoardOffset, rank + BoardOffset, pieceDepth);
            pieceRendererTc.localScale = new Vector3(pieceScale, pieceScale, 1);
            PieceRenderers[Board.GetBoardIndex(file, rank)] = pieceRenderer;
        }

        public void UpdateUI(Board board)
        {
            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var piece = board.GetPiece(file, rank);
                    var sprite = pieceTheme.GetSprite(piece);
                    PieceRenderers[Board.GetBoardIndex(file, rank)].sprite = sprite;
                }
            }
        }
    }
}
