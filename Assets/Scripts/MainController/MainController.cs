using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {


	UIController m_UIPanelController;
	GameController m_GameController;

	public UIController GetUICtrl {
		get { return m_UIPanelController; }

	}
	public GameController GetGameCtrl {
		get {return m_GameController; }
	}
	void Awake(){
		m_GameController = this.transform.Find ("GamePart").GetComponent<GameController>();
		m_UIPanelController = this.transform.Find ("MenuPart").GetComponent<UIController> ();
	}
	// Use this for initialization
	void Start () {
		Init ();		
	}
	void Init(){
		m_GameController.gameObject.SetActive (false);
		m_UIPanelController.gameObject.SetActive (true);
		m_UIPanelController.Init (this);
		m_GameController.Init (this);
	}
	public void HideMenu(){
		m_UIPanelController.gameObject.SetActive (false);
	}



}
