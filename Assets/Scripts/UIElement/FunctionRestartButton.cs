using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionRestartButton : MonoBehaviour {

	public void OnClick () {
		TimeManager.Instance.IsRestarted = true;
	}
}
