using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button menuButton;
    public Button exitButton;
    public GameObject menuOverlay;

    public bool isPaused;

    void Start () 
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(SendToMenu);
        exitButton.onClick.AddListener(ExitGame);

        menuOverlay.SetActive(false);

        isPaused = false;
    }

	void PauseGame()
    {
        isPaused = true;

        if (isPaused == true)
        {
            menuOverlay.SetActive(true);
		    Time.timeScale = 0;
        }  
	}

    void ResumeGame()
    {
        isPaused = false;

        if (isPaused == false)
        {
            menuOverlay.SetActive(false);
		    Time.timeScale = 1;
        }  
    }

    void SendToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
