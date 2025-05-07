using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosaicPuzzleManager : MonoBehaviour
{
    public string correctPieceTag;  // Set this in the Inspector (e.g., "cube1")

    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        {
            mesh.enabled = false; // Initially hide the mesh
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Compare the tag of the object that enters with the correct tag for this place
        if (other.CompareTag(correctPieceTag))
        {
            // Show the mesh once the piece is placed correctly
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                mesh.enabled = true; // Show the mesh
            }

            // Destroy the cube (the piece that was grabbed)
            Destroy(other.gameObject);
        }
    }
}

