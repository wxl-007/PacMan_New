using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {

	enum Orentation{
		Left=1,
		Right,
		Up,
		Down,
	}
	[HideInInspector]
	Orentation curOren= Orentation.Left;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
