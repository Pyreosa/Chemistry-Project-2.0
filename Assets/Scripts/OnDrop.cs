using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
        public GameObject hydroChloride;
        public GameObject sodiumHydrogen;
        public GameObject sodiumChloride;

        private GameObject hydroChlorideMolecule;
        private GameObject sodiumChlorideMolecule;
        private GameObject sodiumHydrogenMolecule;

        private CanvasGroup canvasGroup;
    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }


    void combine(PointerEventData eventData)
        {
            //CREATING HARDCODED REACTIONS
            if(eventData.pointerDrag.tag == "Sodium" && eventData.pointerEnter.tag == "Chloride"
            || eventData.pointerEnter.tag == "Sodium" && eventData.pointerDrag.tag == "Chloride")
                {
                    sodiumChlorideMolecule = Instantiate(sodiumChloride, new Vector3(10, 10), Quaternion.identity);
                    sodiumChlorideMolecule.transform.position = eventData.pointerEnter.transform.position;
                    sodiumChlorideMolecule.transform.SetParent(Utils.tabletop.transform);
                }

            if(eventData.pointerDrag.tag == "Hydrogen" && eventData.pointerEnter.tag == "Chloride" 
            || eventData.pointerEnter.tag == "Hydrogen" && eventData.pointerDrag.tag == "Chloride")
                {
                    hydroChlorideMolecule = Instantiate(hydroChloride, new Vector3(10, 10), Quaternion.identity);
                    hydroChlorideMolecule.transform.position = eventData.pointerEnter.transform.position;
                    hydroChlorideMolecule.transform.SetParent(Utils.tabletop.transform);
                }

            if(eventData.pointerDrag.tag == "Hydrogen" && eventData.pointerEnter.tag == "Sodium" 
            || eventData.pointerEnter.tag == "Hydrogen" && eventData.pointerDrag.tag == "Sodium")
                {
                    sodiumHydrogenMolecule = Instantiate(sodiumHydrogen, new Vector3(10, 10), Quaternion.identity);
                    sodiumHydrogenMolecule.transform.position = eventData.pointerEnter.transform.position;
                    sodiumHydrogenMolecule.transform.SetParent(Utils.tabletop.transform);
                }
        }

     public void OnPointerEnter(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag == null) 
             return;

        if (draggable != null)
            draggable.placeHolderParent = this.transform;
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        //Making the collisions work and the compounds appear
        if (draggable != null && eventData.pointerEnter.tag != "TableTop" && eventData.pointerEnter.tag != "Sodium Hydrogen" && eventData.pointerDrag.tag != "Sodium Hydrogen"
            && eventData.pointerEnter.tag != "Sodium Chloride" && eventData.pointerDrag.tag != "Sodium Chloride"
            && eventData.pointerEnter.tag != "HydroChloride Acid" && eventData.pointerDrag.tag != "HydroChloride Acid")
        {
            draggable.originalParent = this.transform;
            Destroy(eventData.pointerDrag);
            Destroy(eventData.pointerEnter);
            Destroy(draggable.placeHolder);
            combine(eventData);

            Debug.Log(eventData.pointerEnter.tag);
            Debug.Log(eventData.pointerDrag.tag);
        
        } else 
                if (eventData.pointerEnter.tag == "TableTop")
                    draggable.originalParent = this.transform;
    }

     public void OnPointerExit(PointerEventData eventData)
    {
         Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag == null) 
            return;   

        if (draggable != null && draggable.placeHolderParent == this.transform)
            draggable.placeHolderParent = draggable.originalParent;
    }  

}
