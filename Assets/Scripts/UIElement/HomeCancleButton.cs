/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCancleButton : MonoBehaviour {

	public void OnClick () {
		UIManager.Instance.IsHomeActive = false;
		TimeManager.Instance.IsClockStart = true;
	}
}
