using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject nextLevel;

    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    void Update()
    {//Save game every frame.      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {//Pause game no movement.
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void RestartGame()
    {//Restart active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void ResumeGame()
    {//Resume game.
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NextLevel(string newGameLevel)
    {//Go to the next level.   
        SceneManager.LoadScene(newGameLevel);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {//Go to the main menu.
        isPaused = false;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
}
