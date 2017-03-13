using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionPauseButton : MonoBehaviour {
		
	public void OnClick () {
		TimeManager.Instance.IsClockStart = !TimeManager.Instance.IsClockStart;
	}
}
