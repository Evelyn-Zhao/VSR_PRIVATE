using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSpeedDp : MonoBehaviour {

	public void OnValueChanged(int value){

		TimeManager.Instance.SpeedToSet = value;	
	}
}
