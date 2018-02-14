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
	public int WaitingDir{
		get{ return (int)waitingDir;}
	}
	float speed = 4.5f;

	//is super or not 
	bool curState;
	int timer =1;
	bool willStop;
	int[,] stopPos;
	public void Init(){
		curDir = Direction.Left;
		curState = false;
		waitingDir = Direction.non;
	}
	public void SetDirection(int pDir,int[,] pPos = null ){
		//stop first 
		if (pDir == 5 && pPos!= null) {
			willStop = true;
			stopPos = pPos;
			return;
		}
		if (pPos != null) {
		
		}
		//oppsite direciton == 2 
		if (Mathf.Abs ((int)curDir - pDir) != 2) {
			// turn waiting list 
			waitingDir = (Direction)pDir;

		} else {
			//directly change dont wait 
			curDir =(Direction)pDir;
			ChangeDirection ();
		}
	}
	public void SetState(bool pState){
		curState = pState;
	}

	//change dir  
	void ChangeDirection(){
		if (curDir == Direction.Up) {
			this.transform.localEulerAngles = Vector3.back * 90f;
		} else if (curDir == Direction.Left) {
			this.transform.localEulerAngles = Vector3.zero;
		} else if (curDir == Direction.Down) {
			this.transform.localEulerAngles = Vector3.forward * 90;
		} else if (curDir == Direction.Right) {
			this.transform.localEulerAngles = Vector3.forward * 180;
		}
	}
	/// <summary>
	/// Offsets the position when pacman is changing the dir , it should be in the center of the corner 
	/// </summary>
	public void OffsetPos( int[,] pCurPos){
		this.transform.localPosition = new Vector3 (pCurPos[0,0]*47,pCurPos[0,1]*(-47));
	}

	void Update(){
		//timer += Time.deltaTime;
		if (Time.frameCount % 2 == 0) {
			if (curDir == Direction.Left) {
				this.gameObject.transform.localPosition += Vector3.left * speed;
			} else if (curDir == Direction.Right) {
				this.gameObject.transform.localPosition += Vector3.right * speed;
			} else if (curDir == Direction.Up) {
				this.gameObject.transform.localPosition += Vector3.up * speed;
			} else if (curDir == Direction.Down) {
				this.gameObject.transform.localPosition += Vector3.down * speed;
			} else {
				//stop
			}
			if (willStop == true) {
				//Debug.Log ("dis  ==  bewteen "+this.transform.localPosition +" and  "+new Vector3(stopPos[0,0]*47,stopPos[0,1]*(-47),this.transform.localPosition.z)+    ";;;;"+   Vector3.Distance(this.gameObject.transform.localPosition,new Vector3(stopPos[0,0]*47,stopPos[0,1]*(-47),this.transform.localPosition.z)));
				if(Vector3.Distance(this.gameObject.transform.localPosition,new Vector3(stopPos[0,0]*47,stopPos[0,1]*(-47),this.transform.localPosition.z)) <10.0){
					OffsetPos (stopPos);
					willStop = false;
					curDir = Direction.non;
					//turn to other dir 
					if (waitingDir != Direction.non) {
						Debug.Log (waitingDir);
						curDir = waitingDir;
						ChangeDirection ();
						waitingDir = Direction.non;
					}
				}
			}
		}
	}
}
