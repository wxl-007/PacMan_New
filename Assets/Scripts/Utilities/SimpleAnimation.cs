using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleAnimation : MonoBehaviour {
	public Sprite[] aniSprites;
	public bool isPlayAutomatically;
	public bool isLoop;
	public bool isPingPang;
	public int playRat=10;
	bool isPlay;
	int spritesLen=0;
	int counter =0;
	// using for boolen isPingPang, false decrease    true increase
	bool isPing;


	void Start () {
		
		if (isPlayAutomatically) Play ();	
	}

	public void Play(){
		spritesLen = aniSprites.Length;
		isPlay = true;
	}

	public void Pause(){
		isPlay = false;
	}

	public void Stop(){
		isPlay = false;
		this.transform.GetComponent<Image> ().sprite = aniSprites [0];
	}

	void Update(){
		if (isPlay == true) {
			if (Time.renderedFrameCount%playRat ==0) {
				this.transform.GetComponent<Image> ().sprite = aniSprites [counter];
				if (isPingPang == false) {
					counter++;
					if (counter == spritesLen) {
						if (isLoop == true) {
							counter = 0;
						} else
							isPlay = false; 
					}
				} else {
					if (isPing) {
						counter--;
						if (counter == 0) {
							isPing = false;
						} 
					} else {
						counter++;
						if (counter == spritesLen - 1) {
							isPing = true;
						} 
					}
				} 
			}
		}
	}
}
