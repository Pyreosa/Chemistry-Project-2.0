using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    //Canvas canvas = Utils.canvas;

    public Transform originalParent = null;
    public Transform whereMyCardWasParent = null;

    GameObject whereMyCardWas = null;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = .6f; 
        canvasGroup.blocksRaycasts = false;

        // Making a placeHolder
        whereMyCardWas = new GameObject();
        whereMyCardWas.transform.SetParent( this.transform.parent ); 

        LayoutElement layoutElement = whereMyCardWas.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layoutElement.flexibleWidth = 0;
        layoutElement.flexibleHeight = 0;

        whereMyCardWas.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
        
        // Making the Grid Rearrage itself
        originalParent = this.transform.parent;
        whereMyCardWasParent = originalParent;
        this.transform.SetParent( this.transform.parent.parent );
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / Utils.canvas.scaleFactor;

        if (whereMyCardWas.transform.parent != whereMyCardWasParent)
             whereMyCardWas.transform.SetParent( whereMyCardWasParent );

        // Making the placeHolder move its position with me
        int newSiblingIndex = whereMyCardWasParent.childCount;
        
        for (int i = 0 ; i < whereMyCardWasParent.childCount ; i++)
        {
            if (this.transform.position.x < whereMyCardWasParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (whereMyCardWas.transform.GetSiblingIndex() < newSiblingIndex)  newSiblingIndex --;

                break;
            }

        }

        whereMyCardWas.transform.SetSiblingIndex (newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1; 
        canvasGroup.blocksRaycasts = true;

        //Making a placeHolder
        Destroy(whereMyCardWas);

        // Making the Grid Rearrange itself
        this.transform.SetParent( originalParent );
        this.transform.SetSiblingIndex( whereMyCardWas.transform.GetSiblingIndex() );
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
