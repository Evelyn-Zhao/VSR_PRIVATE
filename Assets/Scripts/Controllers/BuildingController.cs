/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BuildingController : Singleton<BuildingController> {


	private string[,] buildingInfo;
	private int countN = 0;
	private int countM = 0;
	private DateTime dt;
	private bool needToResetStatus = true;

	void Awake(){

		readingFile (); //read CSV file and put then in a two dimentional array and then put in script  
		getLists (); //get all nodes in 'surounds' and put names in the attached script.buildingName
	}
	// Use this for initialization
	void Start () {
		checkReset (needToResetStatus);
	}
	
	// Update is called once per frame
	void Update () {
		dt = new DateTime (TimeManager.Instance.Year, TimeManager.Instance.Month, TimeManager.Instance.Day);
		checkReset (needToResetStatus);
		checkList ();
		checkHRLists ();
	}

	private void checkReset (bool b){

		if (b) {
			Transform hr = GameObject.Find ("HRBuildings").transform;
			int children = hr.childCount;
			//loop to inverse every child node under this parent node
			for (int i = 0; i < children; i++) {
				Transform sub = hr.GetChild (i).transform;
				HRBuildingBase currentBase = sub.GetComponent ("HRBuildingBase") as HRBuildingBase;
				currentBase.Status = -1;
				int subchildren = sub.childCount;
				for (int j = 0; j < subchildren; j++) {
					sub.GetChild (j).gameObject.SetActive (false);
				}
			}

			needToResetStatus = false;
		}
	}

	void readingFile()
	{

		//initial the buildingInfo array with the number of buildings
		buildingInfo = new string[373,9];
		//read CSV file and get the info from "/Buildings_v03.xls"
		string filename = Application.dataPath+"/Text/Buildings_v10.csv";
		var reader = new StreamReader(File.OpenRead(filename));

		//break the info into strings
		int i = 0;
		while (!reader.EndOfStream)
		{
			var line = reader.ReadLine();
			var values = line.Split(',');
			for (int j = 0; j < 9; j++) {
				buildingInfo [i,j] = values [j];
				//print ("buildingInfo ["+i+","+j+"]:"+buildingInfo [i,j]);
			}
			i++;
			//for(int i=0; i<values.Length; i++)
			//print ("values:"+values[i]);
		}

	}

	void getLists(){
		// get all nodes from 'surrounds'
		Transform surrounds = GameObject.Find ("Surrounds").transform;
		// and put the name in the script attached to game object
		getAllNodes (surrounds);
	}

	// IMPLEMENT DFS
	public void getAllNodes(Transform t){
		int children = t.childCount;
		for (int i = 0; i < children; i++) {
			if (t.GetChild (i).transform.childCount > 0) {
				getAllNodes (t.GetChild (i));
			} else {
				countN++;
				//print ("building " + countN + " name:" + t.GetChild (i).transform.gameObject.name);
				Transform surroundsTransform = t.GetChild (i).transform;
				BuildingBase currentBase;
				//give every node a 'buildingBase' script
				if(surroundsTransform.GetComponent("BuildingBaese") as BuildingBase == null)
					currentBase = surroundsTransform.gameObject.AddComponent <BuildingBase>();
				else
					currentBase = surroundsTransform.GetComponent("BuildingBaese") as BuildingBase;
				//print ("i am putting the buildingName in the script");
				currentBase.BuildingName = surroundsTransform.gameObject.name;
				for (int j = 0; j < 373; j++) {
					if (surroundsTransform.gameObject.name == buildingInfo [j,2]) {
						//print ("i am putting the "+j+"buildinginfo in the script:"+buildingInfo [j,2]);
						currentBase.BirthDay = Int32.Parse (buildingInfo [j,4]);
						currentBase.BirthYear = Int32.Parse (buildingInfo [j,5]);
						//print ("by:"+buildingInfo [j,6]);
						//print ("dy:"+buildingInfo [j,7]);
						if(buildingInfo [j,6].Equals("na"))
							currentBase.DeathDay = 82;
						else currentBase.DeathDay = Int32.Parse (buildingInfo [j,6]);
						if (buildingInfo [j, 7].Equals ("na"))
							currentBase.DeathYear = 2016;
						else
							currentBase.DeathYear = Int32.Parse (buildingInfo [j, 7]); //this else code is added to fix up the bug
					}//else print("buildings that don't have matched buildingbase:"+surroundsTransform.gameObject.name);
				}
			}
		}
	}


	private void checkHRLists(){
		//print ("i am in check list");
		//print ("m_buildings.Count:"+m_buildings.Count);
		//get the transform of "BigDig_for_Evelyn"
		Transform hr = GameObject.Find ("HRBuildings").transform;
		int children = hr.childCount;
		//loop to inverse every child node under this parent node
		for (int i = 0; i < children; i++) {
			//get the dates info from attached HRBuildingBase
			Transform sub = hr.GetChild (i).transform;
			HRBuildingBase currentBase = sub.GetComponent("HRBuildingBase") as HRBuildingBase;
			int subchildren = sub.childCount;
			int by = currentBase.BirthYear;
			int dy = currentBase.DeathYear;
			switch (currentBase.Status) {
			case -1:
				if (TimeManager.Instance.Year >= by && TimeManager.Instance.Year <= dy) {
					for (int j = 0; j < subchildren; j++) {
						sub.GetChild (j).gameObject.SetActive (true);
					}
					currentBase.Status = 0;
				} else if (TimeManager.Instance.Year > dy) {
					currentBase.Status = 1;
				} else if (TimeManager.Instance.Year < by) {
				}
				break;
			case 0:
				if (TimeManager.Instance.Year > dy) {
					for (int j = 0; j < subchildren; j++) {
						sub.GetChild (j).gameObject.SetActive (false);
					}
					currentBase.Status = 1;
				}

				break;
			case 1:
				break;
			}

		}
	}

	private void returnNodes(Transform t){
		int children = t.childCount;
		for (int i = 0; i < children; i++) {
			if (t.GetChild (i).transform.childCount > 0) {
				returnNodes (t.GetChild (i));
			} else {
				Transform surroundsTransform = t.GetChild (i).transform;
				BuildingBase currentBase = surroundsTransform.GetComponent("BuildingBase") as BuildingBase;
				if (currentBase.BirthYear < TimeManager.Instance.Year || (currentBase.BirthYear == TimeManager.Instance.Year&&currentBase.BirthDay<=dt.DayOfYear )) {
					if(currentBase.DeathYear > TimeManager.Instance.Year || (currentBase.DeathYear == TimeManager.Instance.Year&&currentBase.DeathDay>dt.DayOfYear) )
						//print ("set the building active");
						surroundsTransform.gameObject.SetActive (true);
					else 
						surroundsTransform.gameObject.SetActive (false);
					//surroundsTransform.gameObject.SetActive (true);
				} else {
					//print ("set building inactive");
					surroundsTransform.gameObject.SetActive (false);
					//surroundsTransform.gameObject.SetActive (true);
				}
			}
		}
	}

	// check the state of each building 
	private void checkList(){
		//print ("i am in check list");
		//print ("m_buildings.Count:"+m_buildings.Count);
		Transform surrounds = GameObject.Find ("Surrounds").transform;
		returnNodes (surrounds);
	}

	public bool NeedToResetStatus{
		get{ return needToResetStatus;}
		set{ needToResetStatus = value;}
	}
}
