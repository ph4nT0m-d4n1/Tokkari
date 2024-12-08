using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndMenuHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image buttonBG;
    void Start()
    {
        buttonBG = GetComponent<Image>();
        buttonBG.color = Color.white; 
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (gameObject.name == "playAgainButton")
        {
            buttonBG.color = Color.green;
        }
        else if (gameObject.name == "returnToMenuButton")
        {
            buttonBG.color = Color.yellow;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
	    buttonBG.color = Color.white;
    }
}
