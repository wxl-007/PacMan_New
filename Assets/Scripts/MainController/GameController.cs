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
	public void Init(Object pMainCtrl){
		m_MainObj = (MainController)pMainCtrl;
		m_Map = this.transform.Find ("Panel/MapParentObj").GetComponent<Map>();
	}

	public void SetMap(){
		m_Map.InitMap ();
	}
	//
	public void InitGame(){
		// init data
		curLiveNum = m_InitialLives;
		curLevel = 1;
		curScore = 0;

	}

}
