using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour {

	public void OnClick () {
		UIManager.Instance.IsInfoActive = !UIManager.Instance.IsInfoActive;
	}
}
