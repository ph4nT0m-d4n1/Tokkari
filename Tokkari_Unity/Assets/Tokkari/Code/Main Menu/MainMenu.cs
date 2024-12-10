using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This class defines the main menu of the game, through the use of two buttons and scene manager. 
public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    void Start () 
    {
        //adding event listeners to buttons
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(QuitGame);
    }

	void PlayGame()
    {
		SceneManager.LoadScene(1); //game scene is set as the 2nd scene, i.e. scene1
	}

    void QuitGame ()
    {
        Application.Quit(); //exits the application does nothing until game is built
    }
}

