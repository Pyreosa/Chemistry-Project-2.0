using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandDropZone : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
         private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

     public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) 
             return;

          Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.placeHolderParent = this.transform;
        }
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Debug.Log(eventData.pointerDrag);

        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.originalParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag == null) 
             return;

          Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && draggable.placeHolderParent == this.transform)
        {
            draggable.placeHolderParent = draggable.originalParent;
        }
    }
}
