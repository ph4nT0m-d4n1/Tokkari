using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    void Start () 
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(QuitGame);
    }

	void PlayGame()
    {
		SceneManager.LoadScene(1);
	}

    void QuitGame ()
    {
        Application.Quit();
    }
}

