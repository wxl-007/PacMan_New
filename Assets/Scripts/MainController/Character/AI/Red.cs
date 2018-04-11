using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour,IEnemyBehaviour{

	Animator anim;
	// Mode=1 Scater Mode=2 chase     Mode=3 Frightened
	public int curMode{ set; get;}
	//Up=1,Left=2,Down=3,Right=4, non =5 won't use-+
	public int curDir{ set; get;}
	public int waitingDir{ set; get;}
	public float speed{ set; get;} 
	int[,] turnPos;
	bool realStart;
	public void Init (){
		curDir = 2;
		curMode = 1;
		waitingDir = 5;
		speed = 5;
		anim = this.transform.GetComponent<Animator> ();
	}
	public void SetState(int pState){
		curMode = pState;
		if (pState == 3) {
			ChangeAni (4);
			speed = 2.5f;
			StartCoroutine (EndFrighten ());
		} else {
			StopAllCoroutines ();
			speed = 5f;
			ChangeAni (1);

		}
	}
	public void SetStart (bool pBool){
		realStart = pBool;
	}
	public void ChangeDirection (int pDir,int[,] pTurnPos){
		waitingDir = pDir;
		turnPos = pTurnPos;
	}

	IEnumerator EndFrighten(){
		yield return new WaitForSeconds(6);
		anim.Play ("Flashing");
	}


	public void OffsetPos( int[,] pCurPos){
		this.transform.localPosition = new Vector3 (pCurPos[0,0]*47,pCurPos[0,1]*(-47),-5);
	}
	
	void ChangeAni(int pDir){
		string[] tStrList = {"Red_U","Red_L","Red_D","Red_R","Frightened","Flashing"};
		if (curMode == 3 ) {
			anim.Play (tStrList[4]);
			return;
		}

		anim.Play (tStrList[pDir-1]);

	}
	void Update(){
		if (waitingDir != 5) {
			if (Vector3.Distance (this.gameObject.transform.localPosition, new Vector3 (turnPos [0, 0] * 47, turnPos [0, 1] * (-47), -5)) < 10.0) {
				OffsetPos (turnPos);
				curDir = waitingDir;
				waitingDir = 5;
				if(curMode!=3)
					ChangeAni (curDir);
			}
		}
	}
	void FixedUpdate () {
		if (realStart == false)
			return;
		if (curDir == 2) {
			this.gameObject.transform.localPosition += Vector3.left * speed;
		} else if (curDir == 4) {
			this.gameObject.transform.localPosition += Vector3.right * speed;
		} else if (curDir == 1) {
			this.gameObject.transform.localPosition += Vector3.up * speed;
		} else if (curDir == 3) {
			this.gameObject.transform.localPosition += Vector3.down * speed;
		}
	}
}
