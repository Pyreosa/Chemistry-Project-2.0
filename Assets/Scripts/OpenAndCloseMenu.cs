using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseMenu : MonoBehaviour
{
	Animator animator;
	public GameObject DropDownMenu;

	bool isOpen;
	bool canActivate = true;
	float timeout = 0.8f;

	public void MenuDropDown()
	{
		if (canActivate)
		{

			canActivate = false;
			if (DropDownMenu != null)
			{
				animator = DropDownMenu.GetComponent<Animator>();
				if (animator != null)
				{
					isOpen = animator.GetBool("open");
					animator.SetBool("open", !isOpen);
				}
			}
			Invoke("CooledDown", timeout);
		}
	}
	void CooledDown()
	{
		canActivate = true;
	}
}

