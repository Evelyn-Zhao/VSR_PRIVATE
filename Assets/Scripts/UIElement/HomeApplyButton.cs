/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to implement of the function of apply button on home panel
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HomeApplyButton : MonoBehaviour {

	//when this button is clicked 
	//home panel is invisible
	//the clock starts again
	//and the time is set as user's preference
	public void OnClick () {
		UIManager.Instance.IsHomeActive = false;
		//this is done in function changeVisibility(CanvasGroup cg, bool b)
		//UIManager.Instance.IsClockStart = true;
		//trigger the passdata boolean
		TimeManager.Instance.IsDataPassed = true;
		BuildingController.Instance.NeedToResetStatus = true;
	}


}
