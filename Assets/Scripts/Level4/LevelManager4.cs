using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager4 : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    void Initialized()
    {
        OliveLevel4.FruitCount += CountFruit;
    }
    public void OnDisable()
    {
        OliveLevel4.FruitCount -= CountFruit;
    }
    void Awake()
    {
        Initialized();
    }

    public void CountFruit()
    {
        gameManager.currentOliveCount++;
        gameManager.ProgressBar();

        gameManager.LevelComplete();
    }
}
