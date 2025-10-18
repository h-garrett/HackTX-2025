using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Star star;
    
    void Awake()
    {
        star = GetComponent<Star>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        star.wasClicked();
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

}

