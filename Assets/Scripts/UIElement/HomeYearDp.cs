using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HomeYearDp : MonoBehaviour {

	[SerializeField]
	private Dropdown Ddp;

	[SerializeField]
	private Dropdown Mdp;

	private int year =0;


	public void OnValueChanged(int value){

		year = value + 1788;

		if (Mdp.value == 1) {
			if(TimeManager.Instance.isLeapYear(year))
				UIManager.Instance.recreateDroplist (Ddp,1,29);
			else 
				UIManager.Instance.recreateDroplist (Ddp,1,28);
		}

		TimeManager.Instance.YearToSet = year;
	}
}
