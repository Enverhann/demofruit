using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public GameObject olive;
    [SerializeField] PlayerController player = default;
    [SerializeField] Image inputSystem = default;
    [SerializeField] Image mask = default;
    public int levelOliveCount;
    public int currentOliveCount;
    float fillAmount = 0;
    public GameObject spawner;
    private PauseMenu paused;
    
    void Start()
    {
        Counter();
        paused = GameObject.Find("PauseManager").GetComponent<PauseMenu>();      
    }

    public void ProgressBar()
    {//Progress bar fill.
        fillAmount = (float)currentOliveCount / (float)levelOliveCount;
        mask.fillAmount = fillAmount;
    }
    
    public void LevelComplete()
    {//Level complete,freeze game, next level button appears.
       if(currentOliveCount == levelOliveCount)
        {
            inputSystem.gameObject.SetActive(false);
            player.rb.velocity = Vector3.zero;
            paused.pauseMenu.SetActive(false);
            paused.nextLevel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Counter()
    {//Count olives.
        levelOliveCount = spawner.transform.childCount;
        currentOliveCount = 0;
        mask.fillAmount = 0;

        player.rb.velocity = Vector3.zero;
        
        player.gameObject.SetActive(true);
        inputSystem.gameObject.SetActive(true);
        
    }
}