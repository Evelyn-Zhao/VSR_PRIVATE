/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using Tenkoku;

public class WeatherController : MonoBehaviour {
	
	private GameObject tenkokuModule;
	private string[] timeInfo = new string[2];
    private string[] cloudInfo = new string[10];
    private int i;
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
        //modified by Mike
      //  Debug.Log(ReadData.weatherinfo.Instance.weather_WindDir);
        tenkokuModule.SendMessage ("Tenkoku_SetData", "setLatitude(33.8650),setLongtitude(151.2094)",SendMessageOptions.DontRequireReceiver);
		tenkokuModule.SendMessage ("Tenkoku_SetData", timeInfo[0] ,SendMessageOptions.DontRequireReceiver);
		tenkokuModule.SendMessage ("Tenkoku_SetData", timeInfo[1],SendMessageOptions.DontRequireReceiver);
		tenkokuModule.SendMessage ("Tenkoku_SetData", "weather_cloudCirrusAmt("+ ReadData.weatherinfo.Instance.weather_cloudCirrusAmt+")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_cloudCumulusAmt(" + ReadData.weatherinfo.Instance.weather_cloudCumulusAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_cloudScale(" + ReadData.weatherinfo.Instance.weather_cloudScale + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_cloudSpeed(" + ReadData.weatherinfo.Instance.weather_cloudSpeed + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_FogAmt(" + ReadData.weatherinfo.Instance.weather_FogAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_OvercastAmt(" + ReadData.weatherinfo.Instance.weather_OvercastAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_RainAmt(" + ReadData.weatherinfo.Instance.weather_RainAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_SnowAmt(" + ReadData.weatherinfo.Instance.weather_SnowAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_WindAmt(" + ReadData.weatherinfo.Instance.weather_WindAmt + ")", SendMessageOptions.DontRequireReceiver);
        tenkokuModule.SendMessage("Tenkoku_SetData", "weather_WindDir(" + ReadData.weatherinfo.Instance.weather_WindDir + ")", SendMessageOptions.DontRequireReceiver);

    } 	

}

