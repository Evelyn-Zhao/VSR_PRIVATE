/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

	private int watercurrentState;
	private int waterpreviousState=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		waterController ();
	}

	public void waterController(){
		Transform water = GameObject.Find ("Water").transform;
		int children = water.childCount;
		if (TimeManager.Instance.Year >= 1788 && TimeManager.Instance.Year < 1799) 
			watercurrentState = 1;
		if (TimeManager.Instance.Year >= 1800 && TimeManager.Instance.Year < 1849) 
			watercurrentState = 2;
		if (TimeManager.Instance.Year >= 1850 && TimeManager.Instance.Year < 1899)
			watercurrentState = 3;
		if (TimeManager.Instance.Year >= 1900 && TimeManager.Instance.Year < 1949)
			watercurrentState = 4;
		if (watercurrentState != waterpreviousState) {
			for (int i = 0; i < children; i++) {
				string name = water.GetChild (i).transform.name;
				if (name.Equals ("Aboriginal_1788to1850_TOP")) {
					//if (m_year >= 1788 && m_year < 1850) {
					if (watercurrentState == 1 || watercurrentState == 2) {
						//print ("1788 - 1850");
						setAllNodes (water.GetChild (i).transform, true);
					} else
						setAllNodes (water.GetChild (i).transform, false);
				} else if (name.Equals ("Boats_1800to1849_TOP")) {
					//if (m_year >= 1800 && m_year < 1849) {
					if (watercurrentState == 2){
						setAllNodes (water.GetChild (i).transform, true);
					} else
						setAllNodes (water.GetChild (i).transform, false);
				} else if (name.Equals ("Boats_1850to1899_TOP")) {
					//if (m_year >= 1850 && m_year < 1899) {
					if (watercurrentState == 3){
						setAllNodes (water.GetChild (i).transform, true);
					} else
						setAllNodes (water.GetChild (i).transform, false);
				} else if (name.Equals ("Boats_1900to1949_TOP")) {
					if (watercurrentState == 4){
						setAllNodes (water.GetChild (i).transform, true);
					} else
						setAllNodes (water.GetChild (i).transform, false);
				} else if (name.Equals ("FirstFleet_1788to1799_TOP")) {
					//if (m_year >= 1788 && m_year < 1799) {
					if (watercurrentState == 1){
						setAllNodes (water.GetChild (i).transform, true);
						if (water.GetChild (i).name.Equals ("scarborough")) {
							int subchildren = water.GetChild(i).transform.childCount;

						}
					} else
						setAllNodes (water.GetChild (i).transform, false);
				} else if (name.Equals ("Water_TOP")) {
					setAllNodes (water.GetChild (i).transform, true);
				} else {
					setAllNodes (water.GetChild (i).transform, false);
				}
			}
			waterpreviousState = watercurrentState;
		}
	}

	public void setAllNodes(Transform t, bool b){
		int children = t.childCount;


		//print ("children != 0 ");
		for (int i = 0; i < children; i++) {

			if (t.GetChild (i).transform.childCount > 0) {
				setAllNodes (t.GetChild (i),b);
			} else {
				Transform landscapesTransform = t.GetChild (i).transform;
				landscapesTransform.gameObject.SetActive (b);
				//print ("set the visibility of "+landscapesTransform.gameObject.name);
			}
		}

	}
}
