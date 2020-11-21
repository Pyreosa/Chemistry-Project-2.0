using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

        public GameObject hydroChloride;

        string toBeDestroyed;
        private CanvasGroup canvasGroup;
    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void combine(PointerEventData eventData)
        {
            GameObject molecule = Instantiate(hydroChloride, new Vector3(10, 10), Quaternion.identity);
            molecule.transform.position = eventData.pointerEnter.transform.position;
            molecule.transform.SetParent(Utils.tabletop.transform);
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
        if (draggable != null && eventData.pointerEnter.tag != "TableTop")
        {
            draggable.originalParent = this.transform;
            Destroy(eventData.pointerDrag);
            Destroy(eventData.pointerEnter);
            Destroy(draggable.placeHolder);
            combine(eventData);
            Debug.Log(eventData.pointerDrag.tag);
        } else {
            if(eventData.pointerEnter.tag == "TableTop")
            {
                draggable.originalParent = this.transform;
            }
        }

    }

     public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) 
        {
          return;  
        } 

          Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null && draggable.placeHolderParent == this.transform)
        {
            draggable.placeHolderParent = draggable.originalParent;
        }
    }  

}
