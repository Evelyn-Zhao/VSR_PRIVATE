/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to control the visibility of lanscape 
 * --- according to the internal clock
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		landscapeController ();
	}

	public void landscapeController (){
		Transform landscapes = GameObject.Find ("Landscape").transform;
		int children = landscapes.childCount;
		for (int i = 0; i < children; i++) {
			string name = landscapes.GetChild (i).transform.name;
			//print ("lanscapename:"+name);
			if (name.Equals ("LANDSCAPE_1788_TOP")) {
				if (TimeManager.Instance.Year >= 1788 && TimeManager.Instance.Year < 1800) {
					setAllNodes (landscapes.GetChild (i).transform, true);
				}else setAllNodes (landscapes.GetChild (i).transform, false);
			} else if (name.Equals ("LANDSCAPE_1800_TOP")) {
				if (TimeManager.Instance.Year >= 1800 && TimeManager.Instance.Year < 1850) {
					//landscapes.GetChild (i).transform.gameObject.SetActive (true);
					setAllNodes (landscapes.GetChild (i).transform, true);
					//print ("LANDSCAPE_1800_TOP.SetActive (true)");
				}else setAllNodes (landscapes.GetChild (i).transform, false);
			} else if (name.Equals ("LANDSCAPE_1850_TOP")) {
				if (TimeManager.Instance.Year >= 1850 && TimeManager.Instance.Year < 1900) {
					setAllNodes (landscapes.GetChild (i).transform, true);
					//landscapes.GetChild (i).transform.gameObject.SetActive (true);
					//print ("LANDSCAPE_1850_TOP.SetActive (true)");
				}else setAllNodes (landscapes.GetChild (i).transform, false);
			} else if (name.Equals ("LANDSCAPE_1900_TOP")) {
				if (TimeManager.Instance.Year >= 1900 && TimeManager.Instance.Year < 1950) {
					setAllNodes (landscapes.GetChild (i).transform, true);
					//landscapes.GetChild (i).transform.gameObject.SetActive (true);
					//print ("LANDSCAPE_1900_TOP.SetActive (true)");
				}else setAllNodes (landscapes.GetChild (i).transform, false);
			} else if (name.Equals ("LANDSCAPE_1950_TOP")) {
				if (TimeManager.Instance.Year >= 1950 && TimeManager.Instance.Year < 2000) {
					setAllNodes (landscapes.GetChild (i).transform, true);
					//landscapes.GetChild (i).transform.gameObject.SetActive (true);
					//print ("LANDSCAPE_1950_TOP.SetActive (true)");
				}else setAllNodes (landscapes.GetChild (i).transform, false);
			} else if (name.Equals ("LANDSCAPE_2000_TOP")) {
				if (TimeManager.Instance.Year >= 2000) {
					setAllNodes (landscapes.GetChild (i).transform, true);
					//landscapes.GetChild (i).transform.gameObject.SetActive (true);
					//print ("LANDSCAPE_2000_TOP.SetActive (true)");
				} else setAllNodes (landscapes.GetChild (i).transform, false);
			} else {
				setAllNodes (landscapes.GetChild (i).transform, false);
				//landscapes.GetChild (i).transform.gameObject.SetActive (false);}
				//print ("LANDSCAPE.SetActive (false)");
			}
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
