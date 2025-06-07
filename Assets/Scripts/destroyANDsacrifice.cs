using UnityEngine;

public class destroyANDsacrifice : MonoBehaviour
{
    [SerializeField] private string targetTag = "sacrificeFire";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject);
        }
    }
}
