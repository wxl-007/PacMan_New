using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	public SpriteRenderer[] numSpArr;
	public Sprite[] numSprite;

	int curScore=0;
	int arrLen =0;
	// Use this for initialization
	void Start () {
		arrLen = numSpArr.Length;
		for (int i = 4; i < 7; i++) {
			numSpArr [i].gameObject.SetActive (false);
		}
	}
	//Set score 
	public void SetScore(int pScore){
		if (pScore>=0 && pScore <= 9999999) {
			
			curScore = pScore;
		} else {
			pScore = 9999999;
		}
		ChangeSprite ();
	}

	void ChangeSprite(){
		int tScore = curScore;
		int tLen=  tScore.ToString ().Length;
		for (int i = 0; i < tLen; i++) {
			numSpArr[i].sprite =numSprite[tScore % 10];
			tScore /= 10;
			numSpArr [i].gameObject.SetActive (true);
			if (tLen > 4) {
				numSpArr [0].transform.parent.localPosition = Vector3.right * (tLen - 4) * 60;
			} else
				numSpArr [0].transform.parent.localPosition = Vector3.zero;
				
		}

	}
}
