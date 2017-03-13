/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to control the visibility of 
 * --- surroundings and HRbuildings based on the internal clock
 */
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : Singleton<TimeManager> {

	//this variable is controlled by pause button in timecontrol panel
	private bool isPaused;
	//this variable is controlled by restart button in timecontrol panel
	//will be auto set to be false after reset
	private bool isRestarted;
	private bool isClockStart;
	//this variable controls the setting of data
	//will be auto set to false
	//which acts like a trigger
	private bool isDataPassed;
	private int year;
	//this variable stores the value of year set form home panel
	private int yearToSet;
	//internal variable that drives the clock
	private int month;
	private int monthOffset;
	//this variable stores the value of month set form home panel
	private int monthToSet;
	//internal variable that drives the clock
	private int day;
	//this variable stores the value of day set form home panel
	private int dayToSet;
	//internal variable that drives the clock
	private int hour;
	//this variable stores the value of hour set form home panel
	private int hourToSet;
	//internal variable that drives the clock
	//which cannot be set from home panel
	private int minute;
	private int minuteToSet;
	//internal variable that drives the clock
	//which cannot be set from home panel
	private int second;
	//internal variable that drives the clock
	private int speed;
	//this variable stores the value of speed set form home panel
	private int speedToSet;
	//the total day since 1788
	private int dayCounter;
	//control the second 
	private float secondCounter;
	private int[] monthMax = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

	// Use this for initialization
	void Start () {
		
		isPaused = false;
		isRestarted = false;
		isDataPassed = false;
		year = 1788;
		yearToSet = 1788;
		month = 1;
		monthToSet = 1;
		day = 1;
		dayToSet = 1;
		hour = 0;
		hourToSet = 0;
		minute = 0;
		minuteToSet = 0;
		speed = 0;
		speedToSet = 0;
		second = 0;
		monthOffset = 0;
		secondCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		RestartTime (isRestarted);
		UpdateData (isDataPassed);

		if (year > DateTime.Today.Year) initClock ();
		if (year == DateTime.Today.Year) {
			if (month > DateTime.Today.Month)
				initClock ();
			if (month == DateTime.Today.Month) {
				if (day > DateTime.Today.Day)
					initClock ();
			}
		}
		//when there is not any active panel(onlyOnePanelActive ()==false) 
		//the clock starts
		if (isClockStart) {
			secondCounter += Time.deltaTime;
			if (secondCounter >= 1.0f) {
				secondCounter -= 1.0f;
				ClockUpdate ();
			}
		}
		
	}

	public void initClock (){

		switch (speed) {
		case 0: // speed is one second per second
			year = 1788;
			month = 1;
			day = 1;
			hour = 0;
			minute = 0;
			second = 0;
			break;
		case 1: // speed is one hour per second
			year = 1788;
			month = 1;
			day = 1;
			hour = 0;
			break;
		case 2: // speed is one day per second
			year = 1788;
			month = 1;
			day = 1;
			break;
		case 3: // speed is one month per second
			year = 1788;
			month = 1;
			break;
		case 4: // speed is one year per second
		case 5: // speed is three year per second
		case 6: // speed is five years per second
		case 7: // speed is ten years per second
			year = 1788;
			break;
		}
	}

	public void ClockUpdate (){

		//if speed is one second per second
		switch (speed) {
		case 0: // speed is one second per second
			second++;
			break;
		case 1: // speed is one hour per second
			hour++;
			break;
		case 2: // speed is one day per second
			increaseDay ();
			break;
		case 3: // speed is one month per second
			monthOffset = (isLeap && month == 2) ? 1 : 0;
			//increaseMonth ();
			month++;
			break;
		case 4: // speed is one year per second
			//increaseYear ();
			year++;
			break;
		case 5: // speed is three year per second
			for (int i = 0; i < 3; i++) {
				//increaseYear ();
				year++;
			}
			//increaseYear ();
			break;
		case 6: // speed is five years per second
			for (int i = 0; i < 5; i++) {
				//increaseYear ();
				year++;
			}
			break;
		case 7: // speed is ten years per second
			for (int i = 0; i < 10; i++) {
				//increaseYear ();
				year++;
			}
			break;
		}

		// counting logic 
		if (second > 59) {
			second -= 60;
			minute++;
		}
		if (minute > 59) {
			minute -= 60;
			hour++;
		}
		if (hour > 23) {
			hour -= 24;
			increaseDay();
		}

		if (month > 12) {
			month = 1;
			increaseYear ();
		}

		if (day > monthMax [month] + monthOffset) {
			day = 1;
			increaseMonth ();//m_month ++;
		}

		//if () IF it is more than current date system stays;
	}

	public void increaseDay(){
		dayCounter++;
		day++;

	}

	public void increaseMonth(){
		dayCounter += monthMax [month] + monthOffset;
		month++;
	}

	public void increaseYear(){
		dayCounter += isLeap ? 366 : 365;
		year++;
	}

	public void UpdateData (bool b){

		if (b) {
			year = yearToSet;
			month = monthToSet;
			day = dayToSet;
			hour = hourToSet;
			minute = minuteToSet;
			speed = speedToSet;
			isDataPassed = !isDataPassed;
		}

	}

	public void RestartTime (bool b){

		if (b) {
			initClock ();
			isRestarted = !isRestarted;
		}

	}
	public bool isLeapYear(int value){
		return ((value % 4 == 0 && value % 100 != 0) || value % 400 == 0) ? true : false;
	}
		
	public bool IsRestarted{
		get{ return isRestarted;}
		set{ isRestarted = value;}
	}

	public bool IsClockStart{
		get{ return isClockStart;}
		set{ isClockStart = value;}
	}

	public bool IsDataPassed{
		get{ return isDataPassed;}
		set{ isDataPassed = value;}
	}

	public int Year{
		get{ return year;}
	}

	public int Month{
		get{ return month;}
	}

	public int Day{
		get{ return day;}
		set{ day = value;}
	}

	public int Hour{
		get{ return hour;}
	}

	public int Minute{
		get{ return minute;}
	}

	public int Second{
		get{ return second;}
	}

	public int Speed{
		get{ return speed;}
	}

	public int YearToSet{
		get{ return yearToSet;}
		set{ yearToSet = value;}
	}

	public int MonthToSet{
		get{ return monthToSet;}
		set{ monthToSet = value;}
	}

	public int DayToSet{
		get{ return dayToSet;}
		set{ dayToSet = value;}
	}

	public int HourToSet{
		get{ return hourToSet;}
		set{ hourToSet = value;}
	}

	public int MinuteToSet{
		get{ return minuteToSet;}
		set{ minuteToSet = value;}
	}

	public int SpeedToSet{
		get{ return speedToSet;}
		set{ speedToSet = value;}
	}

	public bool isLeap{
		get{ return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;}
	}
}
