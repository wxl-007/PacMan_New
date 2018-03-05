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
	// Use this for initialization and is 
	int[,] mapArr;
	int timer =0;
	//[HideInInspector]
	public GameObject pacmanObj;
	Pacman PacCtrl; 
	ScoreBoard scoreBoard;
	Transform livesTran;


	public void Init(Object pMainCtrl){
		m_MainObj = (MainController)pMainCtrl;
		m_Map = this.transform.Find ("Panel/MapParentObj").GetComponent<Map>();
		scoreBoard = this.transform.Find ("Panel/Img_Score").GetComponent<ScoreBoard> ();
		livesTran = this.transform.Find ("Panel/Img_Lives");
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

	// init PacMan 
	void InitPacman(){
		pacmanObj.transform.SetParent ( m_Map.transform); 
		pacmanObj.SetActive (true);
		pacmanObj.transform.localEulerAngles = Vector3.zero;
		pacmanObj.transform.localScale = Vector3.one;
		pacmanObj.transform.localPosition = new Vector3(m_Map.bornPoint[1]*47,m_Map.bornPoint[0]*(-47),20)  ;
		PacCtrl = pacmanObj.GetComponent<Pacman> ();
		PacCtrl.Init ();
	}
	// count the score  
	void CalculateScore(int pScore){
		//count score and add lives
		curScore += pScore;
		scoreBoard.SetScore (curScore);
	}
	/// <summary>
	///  locating where the object is in the matrix
	/// </summary>
	int[,] Locator(GameObject pObj){
		Vector3 tPos =  pObj.transform.localPosition;
		return new int[,] {{Mathf.CeilToInt (tPos.x / 47),-Mathf.CeilToInt (tPos.y / 47)} };
	}
	/// <summary>
	/// Determines whether this instance can move the specified pObj pDirNum.
	/// </summary>
	/// <returns><c>true</c> if this instance can move the specified pObj pDirNum; otherwise, <c>false</c>.</returns>
	/// <param name="pObj">P object.</param>
	/// <param name="pDirNum">P dir number.</param>
	 public bool CanMove(GameObject pObj,int pDirNum){
		int[,] tPos = Locator (pObj); 
		if (pObj == pacmanObj) {
			EatPacDots (tPos);
		}
		if (pDirNum == 1) {
			//up  y-1 
			if (mapArr [tPos [0, 1]-1, tPos [0, 0]] > 0)
				return false;
			else
				return true;
		} else if (pDirNum == 2) {
			//left x-1
			if (mapArr [tPos [0, 1], tPos [0, 0]-1] > 0)
				return false;
			else
				return true;
		} else if (pDirNum == 3) {
			//down y+1
			if (mapArr [tPos [0, 1]+1, tPos [0, 0]] > 0)
				return false;
			else
				return true;
		} else if (pDirNum == 4) {
			// right x+1
			if(mapArr [tPos [0, 1] , tPos [0, 0]+1] > 0)
				return false;
			else
				return true;
		}
		return false;
	}
	//
	void EatPacDots(int[,] pPos ){
		
		if (mapArr [pPos [0, 1], pPos [0, 0]] == -1) {
			//eat pac-dots
			// pac-dots = 10
			CalculateScore (10);
		} else if (mapArr [pPos [0, 1], pPos [0, 0]] == -2) {
			//power pellet
			// super mode
			PacCtrl.SetState (true);
			CalculateScore (50);
		}
		mapArr [pPos [0, 1], pPos [0, 0]] = 0;
		m_Map.SetDotsHide (pPos);
	}


	void FixedUpdate(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			// up
			PacCtrl.SetDirection (1);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			PacCtrl.SetDirection (3);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			PacCtrl.SetDirection (2);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			PacCtrl.SetDirection (4);
		}
	}
	void Update(){
			//cannot move forward 
		if (CanMove (pacmanObj, PacCtrl.CurDir) == false) {
			//stop 
			PacCtrl.SetDirection (5,Locator(pacmanObj));
		}
		// can turn in this pos
		if (PacCtrl.WaitingDir != 5) {
			if (CanMove (pacmanObj, PacCtrl.WaitingDir) == true) {
				//turn
				PacCtrl.SetDirection (5, Locator (pacmanObj));
			}		
		}
	}
}
