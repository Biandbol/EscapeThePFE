using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CycleGameObjects : MonoBehaviour
{
    public List<GameObject> gameObjectsToCycle; // Assign in inspector
    private int currentIndex = 0;
    
    void Start()
    {
        // Disable all objects except the first one at start
        for (int i = 0; i < gameObjectsToCycle.Count; i++)
        {
            gameObjectsToCycle[i].SetActive(i == currentIndex);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             NextObject();
        }
       
    }

    public void NextObject()
    {
        // Disable current object
        gameObjectsToCycle[currentIndex].SetActive(false);
        
        // Move to next index with wrap-around
        currentIndex = (currentIndex + 1) % gameObjectsToCycle.Count;
        
        // Enable new current object
        gameObjectsToCycle[currentIndex].SetActive(true);
    }

    public void PreviousObject()
    {
        // Disable current object
        gameObjectsToCycle[currentIndex].SetActive(false);
        
        // Move to previous index with wrap-around
        currentIndex = (currentIndex - 1 + gameObjectsToCycle.Count) % gameObjectsToCycle.Count;
        
        // Enable new current object
        gameObjectsToCycle[currentIndex].SetActive(true);
    }
}