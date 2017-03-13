using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeHourDp : MonoBehaviour {

	public void OnValueChanged(int value){

		TimeManager.Instance.HourToSet = value;

	}
}
