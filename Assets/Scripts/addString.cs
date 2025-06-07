using UnityEngine;

public class addString : MonoBehaviour
{
    public string correctPieceTag;
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        {
            mesh.enabled = false;
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
        }
    }
}
