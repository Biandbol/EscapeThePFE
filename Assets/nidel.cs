using Unity.VisualScripting;
using UnityEngine;

public class nidel : MonoBehaviour

{
    public Transform objecttoshow;
    public float closeDistance = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        float distance = Vector3.Distance(this.transform.position, objecttoshow.position);
        if (distance < closeDistance)
        {
            mesh.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (other.gameObject.CompareTag("N1"))
        {
            mesh.enabled = true;
            Destroy(other.gameObject);
        }
    }


}
