/* --- Author: Wanqi Zhao (Evelyn)
 * --- Created in 06/03/2017
 * --- this class is used to store the information of high resolution buildings
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRBuildingBase : MonoBehaviour{

	[SerializeField]
	private int m_birthDay;
	[SerializeField]
	private int m_birthYear;
	[SerializeField]
	private int m_deathDay;
	[SerializeField]
	private int m_deathYear;
	[SerializeField]
	private int m_status;


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

	public int Status{
		get{ return m_status;}
		set{ m_status = value;}
	}


	// Use this for initialization

	HRBuildingBase(){
		m_birthDay = 1;
		m_birthYear = 1788;
		m_deathDay = 300;
		m_deathYear = 1788;
		m_status = -1;
	}

	HRBuildingBase(int by, int dy){
		m_birthDay = 1;
		m_birthYear = by;
		m_deathDay = 300;
		m_deathYear = dy;
		m_status = -1;
	}


}
