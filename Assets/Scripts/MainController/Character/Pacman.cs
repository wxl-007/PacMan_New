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
	public int CurDir {
		get{ return (int)curDir;}
	}
	float speed = 3.0f;
	Direction waitingDir = Direction.non;
	//is super or not 
	bool curState;
	float timer =0;
	public void Init(){
		curDir = Direction.Left;
		curState = false;
		waitingDir = Direction.non;
	}
	public void SetDirection(int pDir ){
		//stop first 
		if (pDir == 5) {
			
		}
		//oppsite direciton == 2 
		if (Mathf.Abs ((int)curDir - pDir) != 2) {
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
	void OffsetPos(){


	}
	void Update(){
		timer += Time.deltaTime;

		if (timer % 3 == 0) {
			if (curDir == Direction.Left) {
				this.gameObject.transform.localPosition += Vector3.left * speed;
			} else if (curDir == Direction.Right) {
				this.gameObject.transform.localPosition += Vector3.right * speed;
			} else if (curDir == Direction.Up) {
				this.gameObject.transform.localPosition += Vector3.up * speed;
			} else if (curDir == Direction.Down) {
				this.gameObject.transform.localPosition += Vector3.down * speed;
			} else {
			
			
			}
		}

	}
}
