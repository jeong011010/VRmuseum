using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isBtnDown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }// Start is called before the first frame update

    // Update is called once per frame

}
