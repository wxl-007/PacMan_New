using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyBehaviour {

	int curMode{ set; get;}
	int curDir{ set; get;}
	int waitingDir{ set; get;}
	void Init ();
	void SetState(bool pState);
	void ChangeDirection ();
}
