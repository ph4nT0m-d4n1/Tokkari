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

    //Check if pointer enters either button
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //change color to correspond to cursor
        if (gameObject.name == "playButton")
        {
            buttonBG.color = Color.green;
        }
        else if (gameObject.name == "exitButton")
        {
            buttonBG.color = Color.red;
        }

    }

    //account for when cursor leaves
    public void OnPointerExit(PointerEventData pointerEventData)
    {
	    buttonBG.color = Color.white;
    }

}
