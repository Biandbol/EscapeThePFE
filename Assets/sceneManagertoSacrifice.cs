using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagertoSacrifice : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by " + other.gameObject);
        SceneManager.LoadScene("pantheon roooom");
    }
    
}
