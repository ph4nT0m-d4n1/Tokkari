using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image buttonBG;
    void Start()
    {
        buttonBG = GetComponent<Image>();
        buttonBG.color = Color.white; 
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (gameObject.name == "playButton")
        {
            buttonBG.color = Color.green;
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
