using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {
	// mainly controll all ui event including buttons and animation in the menu panel
	private Transform btn_Start,btn_Control,btn_About;
	private GameObject mainPanel = null; 
	MainController m_MainCtrl;
	Button tBtn;
	public void Init (Object pMainCtrl) {
		m_MainCtrl = (MainController)pMainCtrl;
		mainPanel = this.gameObject;
		btn_Start = mainPanel.transform.Find("Btn_Start");
		btn_Control =mainPanel.transform.Find("Btn_Control");
		btn_About = mainPanel.transform.Find("Btn_About");
		if (btn_Start != null && btn_Control != null && btn_About != null) {
			// add listener 
			btn_Start.GetComponent<Button>().onClick.AddListener(OnStartClick);
			btn_Control.GetComponent<Button>().onClick.AddListener(OnControlClick);
			btn_About.GetComponent<Button>().onClick.AddListener(OnAboutClick);
		}
	}

	// will add animation on the menu scene
	void Animation(){
	
	}

	void OnStartClick(){
		InitGame ();
	}

	void InitGame(){
		m_MainCtrl.GetGameCtrl.gameObject.SetActive (true);
		m_MainCtrl.GetGameCtrl.InitGame ();
		m_MainCtrl.HideMenu ();
	}
	void OnControlClick(){
		Debug.Log ("click ctrl btn");
	}
	void OnAboutClick(){
		Debug.Log ("click about btn");
	}

	void OnPointerEnter(PointerEventData pEventData){
		if(pEventData.button.Equals(btn_Start.GetComponent<Button>()))
			Debug.Log ("Enter this area");
	
	}
}
