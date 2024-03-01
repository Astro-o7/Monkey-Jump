using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (optionsMenu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionsMenu.SetActive(false);
                Resume();
            }  
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    
}
