/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tenkoku;

public class WeatherController : MonoBehaviour {
	
	private GameObject tenkokuModule;
	private string[] timeInfo = new string[2];

	// Use this for initialization
	void Start () {
		tenkokuModule = GameObject.Find ("Tenkoku DynamicSky");
	}
	
	// Update is called once per frame
	void Update () {
		weatherController ();
	}

	public void weatherController(){
		timeInfo[0] = "currentYear("+TimeManager.Instance.Year+"),currentMonth("+TimeManager.Instance.Month+"),currentDay("+TimeManager.Instance.Day+")";
		timeInfo[1] = "currenthour("+TimeManager.Instance.Hour+"),currentminute("+TimeManager.Instance.Minute+"),currentsecond("+TimeManager.Instance.Second+")";
		tenkokuModule.SendMessage ("Tenkoku_SetData", "setLatitude(33.8650),setLongtitude(151.2094)",SendMessageOptions.DontRequireReceiver);
		tenkokuModule.SendMessage ("Tenkoku_SetData", timeInfo[0] ,SendMessageOptions.DontRequireReceiver);
		tenkokuModule.SendMessage ("Tenkoku_SetData", timeInfo[1],SendMessageOptions.DontRequireReceiver);
	} 	

}

