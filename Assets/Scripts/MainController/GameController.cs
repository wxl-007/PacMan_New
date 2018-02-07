using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	Map m_Map = null;
	MainController m_MainObj;
	const int m_InitialLives =2;
	int curLiveNum =0;
	int curLevel =1;
	int curScore =0;
	// Use this for initialization
	int[,] mapArr;
	float timer =0.0f;

	[HideInInspector]
	public GameObject pacmanObj;
	public void Init(Object pMainCtrl){
		m_MainObj = (MainController)pMainCtrl;
		m_Map = this.transform.Find ("Panel/MapParentObj").GetComponent<Map>();
	}


	// init game 
	public void InitGame(){
		// init data
		curLiveNum = m_InitialLives;
		curLevel = 1;
		curScore = 0;
		//init map
		m_Map.InitMap ();
		mapArr = m_Map.mapArray;
		InitPacman ();
	}

	//
	void InitPacman(){
		pacmanObj.SetActive (true);
		pacmanObj.transform.localEulerAngles = Vector3.zero;
		pacmanObj.transform.localScale = Vector3.one;
		pacmanObj.transform.localPosition = new Vector3(m_Map.bornPoint[1]*47,m_Map.bornPoint[0]*(-47),20)  ;
	}
	void CalculateScore(){
		//count score and add lives
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer % 3 == 0) {
			
		}

	}

}
