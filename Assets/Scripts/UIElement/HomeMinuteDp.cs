using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMinuteDp : MonoBehaviour {

	public void OnValueChanged(int value){

		TimeManager.Instance.MinuteToSet = value;	
	}
}
