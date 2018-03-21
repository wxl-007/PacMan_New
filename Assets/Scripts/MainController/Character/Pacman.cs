using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {

	enum Direction{
		Up=1,
		Left,
		Down,
		Right,
		non,
	}
	[HideInInspector]
	Direction curDir= Direction.non;
	Direction waitingDir = Direction.non;
	public int CurDir {
		get{ return (int)curDir;}
	}
	//controller can set next dir 
	public int WaitingDir{
		set{waitingDir = (Direction)value; }
		get{ return (int)waitingDir;}
	}
//	Direction lastDir = Direction.non;
	float speed = 4f;

	//is super or not 
	bool curState;
	int timer =1;
	bool willStop;
	int[,] stopPos;
	public void Init(){
		curDir = Direction.Left;
		curState = false;
		waitingDir = Direction.non;
	//	lastDir = Direction.non;
	}
	public void SetDirection(int pDir,int[,] pPos = null ){
		//stop first 

		if (pDir == 5 && pPos!= null) {
			willStop = true;
			stopPos = pPos;
			return;
		}
		if (pDir!=5&&  (int)CurDir - pDir == 0)
			return;
		if (Mathf.Abs ((int)curDir - pDir) != 2 ) {
			// turn waiting list 
			waitingDir = (Direction)pDir;
		} else {
			//directly change dont wait 
		//	lastDir = curDir;
			curDir = (Direction)pDir;
			ChangeDirection ();
		}
	}

	// change statuss
	public void SetState(bool pState){
		curState = pState;
	}

	//change dir  
	void ChangeDirection(){
		this.gameObject.GetComponent<Animator>().enabled = true;
		if (curDir == Direction.Up) {
			this.transform.localEulerAngles = Vector3.back * 90f;
		} else if (curDir == Direction.Left) {
			this.transform.localEulerAngles = Vector3.zero;
		} else if (curDir == Direction.Down) {
			this.transform.localEulerAngles = Vector3.forward * 90;
		} else if (curDir == Direction.Right) {
			this.transform.localEulerAngles = Vector3.forward * 180;
		} else if (curDir == Direction.non) {
			this.gameObject.GetComponent<SimpleAnimation> ().Pause ();
		}
	}
	/// <summary>
	/// Offsets the position when pacman is changing the dir , it should be in the center of the corner 
	/// </summary>
	public void OffsetPos( int[,] pCurPos){
		this.transform.localPosition = new Vector3 (pCurPos[0,0]*47,pCurPos[0,1]*(-47),-5);
	}

	void FixedUpdate(){
		//timer += Time.deltaTime;
		if (curDir == Direction.Left) {
			this.gameObject.transform.localPosition += Vector3.left * speed;
		} else if (curDir == Direction.Right) {
			this.gameObject.transform.localPosition += Vector3.right * speed;
		} else if (curDir == Direction.Up) {
			this.gameObject.transform.localPosition += Vector3.up * speed;
		} else if (curDir == Direction.Down) {
			this.gameObject.transform.localPosition += Vector3.down * speed;
		} else {
			// stop none
		}
	}
	void Update(){
		if (willStop == true) {
			if (Vector3.Distance (this.gameObject.transform.localPosition, new Vector3 (stopPos [0, 0] * 47, stopPos [0, 1] * (-47), -5)) < 10.0) {
				OffsetPos (stopPos);
				willStop = false;
				//lastDir = curDir;
				curDir = Direction.non;
				this.gameObject.GetComponent<Animator>().enabled= false;

				//turn to other dir 
				if (waitingDir != Direction.non) {
					//Debug.Log (waitingDir);
				//	lastDir = curDir;
					curDir = waitingDir;
					waitingDir = Direction.non;
					ChangeDirection ();
				}
			}
		}
	}
}
