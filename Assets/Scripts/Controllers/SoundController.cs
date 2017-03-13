/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to control the sound in VSR
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {


	private int m_dayOfYear = 1;
	private int currentState;
	private int previousState=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//dt = new DateTime (TimeManager.Instance.Year, TimeManager.Instance.Month, TimeManager.Instance.Day);
		//m_dayOfYear = dt.DayOfYear;
	}
	/*
	public void audioController(){

		GameObject soundsA = GameObject.Find ("SoundsA");
		GameObject soundsB = GameObject.Find ("SoundsB");
		AudioSource ausA = soundsA.GetComponent<AudioSource> () as AudioSource;
		AudioSource ausB = soundsB.GetComponent<AudioSource> () as AudioSource;
		AudioClip acA, acB;
		//divid the years into different sections 

		if (m_year == 1788 && m_dayOfYear < 25)
			currentState = 1;
		if (((m_year > 1788 && m_year < 1800)||(m_year == 1788 && m_dayOfYear>=25)) && (m_hour >= 9 && m_hour <= 17))
			currentState = 2;
		if (((m_year > 1788 && m_year < 1800)||(m_year == 1788 && m_dayOfYear>=25)) && (m_hour < 9 || m_hour > 17))
			currentState = 3;
		if (m_year >= 1800 && m_year < 1825 && (m_hour >= 9 && m_hour <= 17)) 
			currentState = 4;
		if (m_year >= 1800 && m_year < 1825 && (m_hour < 9 || m_hour > 17)) 
			currentState = 5;
		if (m_year >= 1825 && m_year < 1850 && (m_hour >= 9 && m_hour <= 17))
			currentState = 6;
		if (m_year >= 1825 && m_year < 1850 && (m_hour < 9 || m_hour > 17))
			currentState = 7;
		if (m_year >= 1850 && m_year < 1900 && (m_hour >= 9 && m_hour <= 17))
			currentState = 8;
		if (m_year >= 1850 && m_year < 1900 && (m_hour < 9 || m_hour > 17))
			currentState = 9;
		if (m_year >= 1900 && m_year < 1950 && (m_hour >= 9 && m_hour <= 17))
			currentState = 10;
		if (m_year >= 1900 && m_year < 1950 && (m_hour < 9 || m_hour > 17))
			currentState = 11;
		if (m_year >= 1950 && m_year < 2000 && (m_hour >= 9 && m_hour <= 17))
			currentState = 12;
		if (m_year >= 1950 && m_year < 2000 && (m_hour < 9 || m_hour > 17))
			currentState = 13;

		if (currentState != previousState) {
			//print ("currentState:"+currentState);
			switch (currentState) {
			case 1:
				acA = Resources.Load ("1788_Pre_Arrival_8bit") as AudioClip;
				acB = null;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 2:
				acA = Resources.Load ("Sounds/1788_Post_Arrival_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1788_Post_Arrival_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 3:
				acA = null;
				acB = Resources.Load ("Sounds/1788_Post_Arrival_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 4:
				acA = Resources.Load ("Sounds/1800_1825_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1800_1825_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 5:
				acA = null;
				acB = Resources.Load ("Sounds/1800_1825_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 6:
				acA = Resources.Load ("Sounds/1825_1850_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1825_1850_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 7:
				acA = null;
				acB = Resources.Load ("Sounds/1825_1850_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 8:
				acA = Resources.Load ("Sounds/1850_1900_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1850_1900_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 9:
				acA = null;
				acB = Resources.Load ("Sounds/1850_1900_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 10:
				acA = Resources.Load ("Sounds/1900_1950_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1900_1950_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 11:
				acA = null;
				acB = Resources.Load ("Sounds/1900_1950_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 12:
				acA = Resources.Load ("Sounds/1950_2000_A_8bit") as AudioClip;
				acB = Resources.Load ("Sounds/1950_2000_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			case 13:
				acA = null;
				acB = Resources.Load ("Sounds/1950_2000_B_8bit") as AudioClip;
				setAudio (ausA, ausB, acA, acB);
				break;
			}
			previousState = currentState;
		}
	}

	public void setAudio(AudioSource ausA, AudioSource ausB, AudioClip acA, AudioClip acB){

		ausA.clip = acA;
		ausB.clip = acB;

		if (acA != null) {
			ausA.Play ();
			ausA.loop = true;
		}
		if (acB != null) {
			ausB.Play ();
			ausB.loop = true;
		}

	}*/
}
