using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    void Initialized()
    {
        Collide.OliveCount += Count;
    }

    public void OnDisable()
    {
        Collide.OliveCount -= Count;
    }

    private void Awake()
    {
        Initialized();
    }

    public void Count()
    {
        gameManager.currentOliveCount++;
        gameManager.ProgressBar();

        gameManager.LevelComplete();
    }
}
