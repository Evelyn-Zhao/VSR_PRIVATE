/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of surrounding buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour {

	[SerializeField]
	private string m_buildingName;
	[SerializeField]
	private int m_birthDay;
	[SerializeField]
	private int m_birthYear;
	[SerializeField]
	private int m_deathDay;
	[SerializeField]
	private int m_deathYear;

	public string BuildingName{
		get{ return m_buildingName;}
		set{ m_buildingName = value;}
	}

	public int BirthDay {
		get { return m_birthDay; }
		set { m_birthDay = value; }
	}

	public int BirthYear {
		get { return m_birthYear; }
		set { m_birthYear = value; }
	}

	public int DeathDay{
		get{ return m_deathDay;}
		set{ m_deathDay = value;}
	}

	public int DeathYear{
		get{ return m_deathYear;}
		set{ m_deathYear = value;}
	}

	// Use this for initialization
	void Awake () {

		m_birthDay = 25;
		m_birthYear = 1788;
		m_deathDay = 25;
		m_deathYear = 1788;
	}

}
