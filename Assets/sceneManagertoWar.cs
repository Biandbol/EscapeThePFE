using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagertoWar : MonoBehaviour
{
    /*void Start(Collision Collider)
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("War Roooom", LoadSceneMode.Additive);
    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by " + other.gameObject);
        SceneManager.LoadScene("War Roooom");
    }
}

