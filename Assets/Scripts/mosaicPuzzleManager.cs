using UnityEngine;

public class mosaicPuzzleManager : MonoBehaviour
{
    public string correctPieceTag;  // Set this in the Inspector (e.g., "cube1")
    public float hoverHeight = 0.5f;
    public Color correctColor = new Color(0, 1, 0, 0.5f); // Green with 50% opacity
    public Color wrongColor = new Color(1, 0, 0, 0.5f);   // Red with 50% opacity
    public GameObject rewardPrefab;
    public Transform spawnPoint;

    private GameObject lastHoveredPiece;

    void Start()
    {
        // Initially hide the mesh
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        {
            mesh.enabled = false;
        }
    }

    void Update()
    {
        GameObject currentHoveredPiece = null;

        // Check all puzzle pieces
        for (int i = 1; i <= 25; i++)
        {
            GameObject piece = GameObject.FindWithTag("cube" + i);
            if (piece == null) continue;

            // Check if piece is hovering over this place
            if (IsHovering(piece.transform))
            {
                currentHoveredPiece = piece;
                bool isCorrect = piece.tag == correctPieceTag;
                SetColor(piece, isCorrect ? correctColor : wrongColor);
            }
        }

        lastHoveredPiece = currentHoveredPiece;
    }

    bool IsHovering(Transform piece)
    {
        Vector3 placePos = transform.position;
        Vector3 piecePos = piece.position;

        return Mathf.Abs(piecePos.x - placePos.x) < 0.5f &&
               Mathf.Abs(piecePos.z - placePos.z) < 0.5f &&
               piecePos.y > placePos.y &&
               piecePos.y < placePos.y + hoverHeight;
    }

    void SetColor(GameObject obj, Color color)
    {
        Material mat = obj.GetComponent<Renderer>().material;
        mat.color = color;

        // Enable transparency if needed
        if (color.a < 1f)
        {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.EnableKeyword("_ALPHABLEND_ON");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctPieceTag))
        {
            // Show the mesh
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                mesh.enabled = true;
            }

            // Destroy the cube
            Destroy(other.gameObject);
            SpawnReward();
        }
    }
    private void SpawnReward()
    {
        Instantiate(rewardPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("[Puzzle] Correct! Reward spawned.");
    }
}

