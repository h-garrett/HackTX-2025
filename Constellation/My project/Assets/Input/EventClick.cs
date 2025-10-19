using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Star star;
    public UIManager manageUI;
    private Coroutine hoverCoroutine;


    void Awake()
    {
        star = GetComponent<Star>();
        manageUI = FindFirstObjectByType<UIManager>();

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
        star.setHovered(true);
        manageUI.ShowTask(star.task);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(HideHoverDelayed());
        }
        hoverCoroutine = StartCoroutine(HideHoverDelayed());

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    IEnumerator HideHoverDelayed()
    {
        yield return new WaitForSeconds(0.2f);
        manageUI.HideTask();
        star.setHovered(false);
    }

}

