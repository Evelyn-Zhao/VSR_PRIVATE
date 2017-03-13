using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HomeMonthDp : MonoBehaviour {

	[SerializeField]
	private Dropdown Ydp;

	[SerializeField]
	private Dropdown Ddp;

	// Use this for initialization
	public void OnValueChanged(int value){
		if (value == 1) {
			if(TimeManager.Instance.isLeapYear(Ydp.value+1788))
				UIManager.Instance.recreateDroplist (Ddp,1,29);
			else 
				UIManager.Instance.recreateDroplist (Ddp,1,28);
		}

		if (value == 0||value == 2||value == 4||value == 6||value == 7|| value == 9|| value == 11 )
			UIManager.Instance.recreateDroplist (Ddp,1,31);
		if (value == 3||value == 5||value == 8||value == 10)
			UIManager.Instance.recreateDroplist (Ddp,1,30);
		TimeManager.Instance.MonthToSet = value + 1;
	}

	
}
