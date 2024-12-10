using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndMenuHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Class defining the death screen or "End Menu"
    Image buttonBG;
    void Start()
    {
        buttonBG = GetComponent<Image>();
        buttonBG.color = Color.white; 
    }

    //when mouse hovers over button
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //change colors based on which button is being hovered on
        if (gameObject.name == "playAgainButton")
        {
            buttonBG.color = Color.green;
        }
        else if (gameObject.name == "returnToMenuButton")
        {
            buttonBG.color = Color.yellow;
        }
    }

    //when user takes cursor off of object
    public void OnPointerExit(PointerEventData pointerEventData)
    {
	    buttonBG.color = Color.white;
    }
}
