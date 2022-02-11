using UnityEngine;

namespace UI
{
    public class BoardUI : MonoBehaviour
    {
        
        public float pieceDepth = -0.1f;
        public Color darkColor = new Color(0.59f, 0.69f, 0.45f);
        public Color lightColor = new Color(0.93f, 0.93f, 0.82f);

        private const float BoardOffset = -3.5f;
        private MeshRenderer[,] _squareRenderers;
        private SpriteRenderer[,] _squarePieceRenderers;
        private readonly char[] _fileChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};

        private void Start()
        {
            _squareRenderers = new MeshRenderer[8, 8];
            _squarePieceRenderers = new SpriteRenderer[8, 8];
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
            _squareRenderers[file, rank] = square.gameObject.GetComponent<MeshRenderer>();
            _squareRenderers[file, rank].material = squareMaterial;

            // Create piece sprite renderer for current square
            var pieceRenderer = new GameObject("Piece").AddComponent<SpriteRenderer>();
            var pieceRendererTc = pieceRenderer.transform;
            pieceRendererTc.parent = square;
            pieceRendererTc.position = new Vector3(file, rank, pieceDepth);
            _squarePieceRenderers[file, rank] = pieceRenderer;
        }
    }
}
