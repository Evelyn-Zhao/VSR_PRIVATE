using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCancleButton : MonoBehaviour {

	public void OnClick () {
		UIManager.Instance.IsInfoActive = false;
	}
}
