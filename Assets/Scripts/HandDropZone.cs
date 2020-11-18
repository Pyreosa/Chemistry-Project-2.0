using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
     private CanvasGroup canvasGroup;

   

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

     public void OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null) return;

          Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if (draggable != null)
        {
            draggable.whereMyCardWasParent = this.transform;
        }
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on" + gameObject.name);

        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if (draggable != null)
        {
            draggable.originalParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag == null) return;

          Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if (draggable != null && draggable.whereMyCardWasParent == this.transform)
        {
            draggable.whereMyCardWasParent = draggable.originalParent;
        }
    }
}
