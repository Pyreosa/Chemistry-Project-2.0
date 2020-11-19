using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

        public GameObject hydroChloride;
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
    

        //   if (eventData.pointerDrag != null) 
        //   {
        //       combine(eventData);
        //       Destroy(eventData.pointerEnter);
        //       Destroy(eventData.pointerDrag);
        //   }

    }

    //   void combine(PointerEventData eventData)
    //   {
    //       GameObject molecule = Instantiate(hydroChloride, new Vector3(10, 10), Quaternion.identity);
    //       molecule.transform.position = eventData.pointerEnter.transform.position;
    //       molecule.transform.SetParent(Utils.textureRender.transform);
    //   }
    
}
