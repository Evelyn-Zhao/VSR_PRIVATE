/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to implement of the switch of camera
 * --- which achieve the switch between top view camera and first person controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraController : Singleton<CameraController> {

	[SerializeField]
	private Camera TopViewCamera;
	[SerializeField]
	private GameObject FirstPersonController;

	private bool isWanderModeOn;
	// Use this for initialization
	void Start () {
		isWanderModeOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isWanderModeOn){
			//switch camera fisrt person controller
			TurnOnWanderMode(true);
			TurnOnTopViewMode(false);
		}else{
			TurnOnWanderMode(false);
			TurnOnTopViewMode(true);
		}
	}

	public void TurnOnWanderMode(bool b){
		FirstPersonController.GetComponent<CharacterController> ().enabled = b;
		FirstPersonController.GetComponent<FirstPersonController> ().enabled = b;
		FirstPersonController.GetComponentInChildren<Camera> ().enabled = b;
	}

	public void TurnOnTopViewMode(bool b){
		TopViewCamera.GetComponent<Camera> ().enabled = b;
	}

	public bool IsWanderModeOn{
		get{ return isWanderModeOn;}
		set{ isWanderModeOn = value;}
	}
}
