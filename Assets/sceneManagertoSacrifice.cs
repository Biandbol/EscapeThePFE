using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagertoSacrifice : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("pantheon roooom");
        }

    }
}
