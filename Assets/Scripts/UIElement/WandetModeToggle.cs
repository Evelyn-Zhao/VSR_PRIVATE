using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WandetModeToggle : MonoBehaviour {

	public void OnValueChanged(Boolean b){

		CameraController.Instance.IsWanderModeOn = b;
	}
}
