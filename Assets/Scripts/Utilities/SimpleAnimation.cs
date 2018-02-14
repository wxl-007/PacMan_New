using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleAnimation : MonoBehaviour {
	public Sprite[] aniSprites;
	public float playRat=10;
	public bool isPlayAutomatically;
	public bool isLoop;
	void Start () {
		if (isPlayAutomatically) Play ();	
	}

	public void Play(){
		StartCoroutine (PlayAni());
	}
	public void StopPlay(){
		StopCoroutine (PlayAni());
		this.transform.GetComponent<Image> ().sprite = aniSprites [0];
	}
	IEnumerator PlayAni(){
		int tLen = aniSprites.Length;
		for (int i = 0; i < tLen; i++) {
			this.transform.GetComponent<Image> ().sprite = aniSprites [i];
			yield return new WaitForSeconds (8.0f/playRat);
			if (isLoop == true)
				if(i==tLen-1)
					i = -1;
		}
	}
	

}
