using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCloseButton : MonoBehaviour {

	public void OnClick () {
		UIManager.Instance.IsSettingActive = false;
	}
}
