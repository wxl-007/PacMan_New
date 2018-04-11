using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyBehaviour {

	int curMode{ set; get;}
	int curDir{ set; get;}
	int waitingDir{ set; get;}
	float speed{ set; get;}
	void Init ();
	void SetState(int pState);
	void ChangeDirection (int pDir,int[,] pos);
}
