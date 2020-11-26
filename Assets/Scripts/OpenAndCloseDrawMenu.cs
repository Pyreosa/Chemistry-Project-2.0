using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class OpenAndCloseDrawMenu : MonoBehaviour
{
    Animator animator;
    public GameObject[] DropDownElements;
    public GameObject DropDownMenu;
    
    bool isActive;
    
    public void ElementsDropDown()
    {
         for (int i = 0 ; i < DropDownElements.Length; ++i)
         {
             animator = DropDownMenu.GetComponent<Animator>();
             if (DropDownElements[i] != null && animator.GetCurrentAnimatorStateInfo(0).IsName("closedMenu") == false)
                {
                    isActive = DropDownElements[i].activeSelf;
                    DropDownElements[i].SetActive(!isActive);
                }
        }
    }
}
