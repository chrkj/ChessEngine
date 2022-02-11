using UnityEngine;

public class BoardUI : MonoBehaviour
{

    public float pieceDepth = 0.5f;
    public Color darkColor = new Color(1, 1, 1);
    public Color lightColor = new Color(0,0,0);
    
    private MeshRenderer[,] _squareRenderers;
    private SpriteRenderer[,] _squarePieceRenderers;
    
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
        square.name = "" + file + rank;
        square.position = new Vector3(file, rank, 0f);
        
        var squareMaterial = new Material(Shader.Find("Unlit/Color"));
        squareMaterial.color = color;
        _squareRenderers[file, rank] = square.gameObject.GetComponent<MeshRenderer> ();
        _squareRenderers[file, rank].material = squareMaterial;

        // Create piece sprite renderer for current square
        var pieceRenderer = new GameObject ("Piece").AddComponent<SpriteRenderer> ();
        var pieceRendererTc = pieceRenderer.transform;
        pieceRendererTc.parent = square;
        pieceRendererTc.position = new Vector3(file, rank, pieceDepth);
        _squarePieceRenderers[file, rank] = pieceRenderer; 
    }


}
