using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image buttonBG;
    void Start()
    {
        buttonBG = GetComponent<Image>();
        buttonBG.color = Color.white; 
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (gameObject.name == "resumeButton")
        {
            buttonBG.color = Color.green;
        }
        else if (gameObject.name == "mainMenuButton")
        {
            buttonBG.color = Color.yellow;
        }
        else if (gameObject.name == "exitButton")
        {
            buttonBG.color = Color.red;
        }

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
	    buttonBG.color = Color.white;
    }

}
