using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button playAgainButton;
    public Button returnToMenuButton;
    public GameObject endScreenOverlay;

    public bool isGameOver;
    void Start()
    {
        //adding event listeners to buttons
        playAgainButton.onClick.AddListener(PlayAgain);
        returnToMenuButton.onClick.AddListener(ReturnToMenu); 

        endScreenOverlay.SetActive(false); //setting the image containing the end screen items as inactive

        isGameOver = false; //gameOver is set to false because the game hasn't ended
    }

    public void GameOver() //this is called when the seal collides with the icebergs
    {
        isGameOver = true;

        if (isGameOver == true)
        {
            endScreenOverlay.SetActive(true);
		    Time.timeScale = 0;
        }  
    }

    void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1); //game scene is set as the 2nd scene, i.e. scene1
    }

    void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); //menu scene is 1st scene, i.e. scene0
    }
}
