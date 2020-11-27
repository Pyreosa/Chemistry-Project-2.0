using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public partial class OpenAndCloseDrawMenu : MonoBehaviour
{
	Animator animator;
	public GameObject[] DropDownElements;
	public GameObject DropDownMenu;

	bool isActive;

	float timeout = 0.8f;
	bool canActivate = true;

	public void ElementsDropDown()
	{
		if (canActivate)
		{

			canActivate = false;
			for (int i = 0; i < DropDownElements.Length; ++i)
			{
				animator = DropDownMenu.GetComponent<Animator>();
				if (DropDownElements[i] != null && animator.GetCurrentAnimatorStateInfo(0).IsName("closedMenu") == false)
				{
					isActive = DropDownElements[i].activeSelf;
					DropDownElements[i].SetActive(!isActive);
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
