using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Draggable : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IDragHandler, IEndDragHandler
{
        Canvas canvas = Utils.canvas;

        public Transform originalParent = null;
        public Transform placeHolderParent = null;

        public GameObject placeHolder = null;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Making a placeHolder
        placeHolder = new GameObject();
        placeHolder.transform.SetParent( this.transform.parent ); 

        LayoutElement layoutElement = placeHolder.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layoutElement.flexibleWidth = 0;
        layoutElement.flexibleHeight = 0;

        placeHolder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
        
        // Making the Grid Rearrage itself
        originalParent = this.transform.parent;
        placeHolderParent = originalParent;
        this.transform.SetParent( this.transform.parent.parent );

        canvasGroup.alpha = .6f; 
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / Utils.canvas.scaleFactor;

        if (placeHolder.transform.parent != placeHolderParent)
             placeHolder.transform.SetParent( placeHolderParent );

        // Making the placeHolder move its position with the dragged element
        int newSiblingIndex = placeHolderParent.childCount;
        
        for (int i = 0 ; i < placeHolderParent.childCount ; i++)
        {
            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)  
                    newSiblingIndex --;
                    
                break;
            }
        }

        placeHolder.transform.SetSiblingIndex( newSiblingIndex );
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1; 
        canvasGroup.blocksRaycasts = true;

        Destroy( placeHolder );

        // Making the Grid Rearrange itself
        this.transform.SetParent( originalParent );
        this.transform.SetSiblingIndex( placeHolder.transform.GetSiblingIndex() );
    }
}
