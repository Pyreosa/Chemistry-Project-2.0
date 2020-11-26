using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseMenu : MonoBehaviour
{
    Animator animator;
    public GameObject DropDownMenu;
    
    bool isOpen;

    public void MenuDropDown()
    {
        if(DropDownMenu != null)
        {
            animator = DropDownMenu.GetComponent<Animator>();
            if(animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }
}

