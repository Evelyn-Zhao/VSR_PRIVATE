using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDayDp : MonoBehaviour {

	private int day =0;

	public void OnValueChanged(int value){

		TimeManager.Instance.DayToSet = value + 1;
	}

}
