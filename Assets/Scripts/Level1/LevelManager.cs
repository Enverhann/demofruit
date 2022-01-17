using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    void Initialized()
    {
        AreaMagnet.OliveEntered += CountOlives;
    }

    public void OnDisable()
    {
        AreaMagnet.OliveEntered -= CountOlives;
    }
    void Awake()
    {
        Initialized();
    }

    public void CountOlives()
    {
        gameManager.currentOliveCount++;
        gameManager.ProgressBar();

        gameManager.LevelComplete();
        
    }
}
