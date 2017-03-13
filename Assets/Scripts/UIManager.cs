/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to manage the visibility of the UI elements
 * --- based on the users' interaction
 */
using System;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using System.Runtime.InteropServices;
using UnityEditor;

public class UIManager : Singleton<UIManager> {

	[SerializeField]
	private GameObject ModePanel;
	[SerializeField]
	private GameObject FunctionPanel;
	[SerializeField]
	private GameObject GeneralInfoPanel;
	[SerializeField]
	private GameObject HomePanel;
	[SerializeField]
	private GameObject SettingPanel;
	[SerializeField]
	private GameObject InfoPanel;
	[SerializeField]
	private Toggle WanderMode;
	[SerializeField]
	private Text date;
	[SerializeField]
	private Text time;
	[SerializeField]
	private Text weather;
	[SerializeField]
	private Dropdown yearDp;
	[SerializeField]
	private Dropdown monthDp;
	[SerializeField]
	private Dropdown dayDp;
	[SerializeField]
	private Dropdown hourDp;
	[SerializeField]
	private Dropdown minuteDp;
	[SerializeField]
	private Dropdown speedDp;
	[SerializeField]
	private Button PauseButton;


	//this variable stores the active toggle
	//which decides that which mode is active
	private IEnumerable<Toggle> activeToggle;

	//whether homepanel is active
	private bool isHomeActive;
	private bool isSettingActive;
	private bool isInfoActive;
	private Sprite pauseSp;
	private Sprite startSp;

	void Start () {
		//activeToggle = WanderMode;

		isHomeActive = true;
		isSettingActive = false;
		isInfoActive = false;
		//set up the home panel dropdown menus
		recreateDroplist(yearDp, 1788, ((DateTime.Today.Year-1788)+1));
		recreateDroplist(dayDp, 1, 31);
		recreateDroplist(hourDp, 0, 23);
		recreateDroplist(minuteDp, 0, 59);
		pauseSp = Resources.Load<Sprite>("UIImage/pausebutton");
		startSp = Resources.Load<Sprite>("UIImage/playbutton");
	}

	// Update is called once per frame
	void Update () {
		RegularUIUpdate ();
		RegularGeneralInfoUpdate ();
	}

	public void RegularGeneralInfoUpdate (){
		//uodate the text on the general info panel
		//includes date and time and weather (need to be implemented in the future)
		time.text = "Time: "+string.Format("{0:00}:{1:00}:{2:00}", TimeManager.Instance.Hour, TimeManager.Instance.Minute, TimeManager.Instance.Second);
		date.text = "Date: "+string.Format("{0}/{1}/{2}", TimeManager.Instance.Year, TimeManager.Instance.Month, TimeManager.Instance.Day);
		//weather.text = "Weather: Sunny";
	}

	public void RegularUIUpdate (){
		//this function is responsible to check the activity 
		//of home panel, setting panel and info panel
		//at most just one of them could be active at one time
		setHomePanelActive(isHomeActive);
		setSettingPanelActive(isSettingActive);
		setInfoPanelActive(isInfoActive);
		if(TimeManager.Instance.IsClockStart)
			PauseButton.GetComponent<Image>().sprite = pauseSp;
		else
			PauseButton.GetComponent<Image>().sprite = startSp;
	}
		
	private void setHomePanelActive(bool b){
		CanvasGroup cg = HomePanel.GetComponent<CanvasGroup> ();
		changeVisibility (cg, b);
	}

	private void setSettingPanelActive(bool b){
		CanvasGroup cg = SettingPanel.GetComponent<CanvasGroup> ();
		changeVisibility (cg, b);
	}

	private void setInfoPanelActive(bool b){
		CanvasGroup cg = InfoPanel.GetComponent<CanvasGroup> ();
		changeVisibility (cg, b);
	}

	private bool currentVisibility(float f){
		if (f == 0)
			return false;
		else
			return true;
	}

	private void changeVisibility(CanvasGroup cg, bool b){

		//to save the computational time only if
		//the status of panel changes then change the visibility of the panel 
		//and also need to make sure just one panel is active 
		//which means once one is active then inactive the function panel, mode panel and general info panel
		//and clock pause !!!!!!!!!!!!!!!!!!!!!!!!!

		if (currentVisibility(cg.alpha) != b) {
			if (b)
				cg.alpha = 1;
			else
				cg.alpha = 0;

			cg.interactable = b;
			cg.blocksRaycasts = b;

			if(cg.gameObject.name.Equals("HomePanel")&&b){
				yearDp.value = TimeManager.Instance.Year - 1788;
				monthDp.value = TimeManager.Instance.Month - 1;
				dayDp.value = TimeManager.Instance.Day - 1;
				hourDp.value = TimeManager.Instance.Hour;
				minuteDp.value = TimeManager.Instance.Minute;
				speedDp.value = TimeManager.Instance.Speed;
			}

			//need to think
			if (onlyOnePanelActive ()) {
				ModePanel.GetComponent<CanvasGroup> ().interactable = false;
				FunctionPanel.GetComponent<CanvasGroup> ().interactable = false;
				GeneralInfoPanel.GetComponent<CanvasGroup> ().interactable = false;
				TimeManager.Instance.IsClockStart = false;
			} else {
				ModePanel.GetComponent<CanvasGroup> ().interactable = true;
				FunctionPanel.GetComponent<CanvasGroup> ().interactable = true;
				GeneralInfoPanel.GetComponent<CanvasGroup> ().interactable = true;
				TimeManager.Instance.IsClockStart = true;
			}
		}


			
	}

	private bool onlyOnePanelActive(){
		if ((isHomeActive && !isSettingActive && !isInfoActive) || (!isHomeActive && !isSettingActive && isInfoActive) || (!isHomeActive && isSettingActive && !isInfoActive))
			return true;
		else
			return false;
	}

	public void recreateDroplist(Dropdown dp, int start, int value){
		
		if (dp.options.Capacity != value) {
			dp.ClearOptions ();
			List<string> options = new List<string> ();
			for (int i = 0; i < value; i++) {
				options.Add ((start+i).ToString ());
			}
			dp.options.Capacity = value;
			dp.AddOptions (options);
			dp.RefreshShownValue ();
			//? everytime that day dropdown gets reset 
			//then the first item is default choice
			//need to reset the day to 1
			TimeManager.Instance.Day = 1;
		}
	}

	public bool IsHomeActive{
		get { return isHomeActive;}
		set { isHomeActive = value;}
	}

	public bool IsSettingActive {
		get { return isSettingActive; }
		set { isSettingActive = value; }
	}

	public bool IsInfoActive {
		get { return isInfoActive; }
		set { isInfoActive = value; }
	}
		
}
