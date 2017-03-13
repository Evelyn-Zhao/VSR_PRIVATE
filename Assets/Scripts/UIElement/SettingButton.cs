using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	public void OnClick () {
		UIManager.Instance.IsSettingActive = !UIManager.Instance.IsSettingActive;
	}
}
