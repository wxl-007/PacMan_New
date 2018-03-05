using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    /* original game is designed as a 28x36 grid to make evey element to do anything.
     * So I will use the same thought to design this game.
     */
    // Use this for initialization
     const int m_column = 28, m_row = 31; 
	 [HideInInspector] 
	 public int[] bornPoint = {23,14};  
     int[,] originalMap = new int[31, 28] {
       // 1  2  3  4  5  6  7  8  9  0  1  2  3  4  5  6  7  8  9  0  1  2  3  4  5  6  7  8 
        {17,26,26,26,26,26,26,26,26,26,26,26,26,43,42,26,26,26,26,26,26,26,26,26,26,26,26,16},
        {19,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 9, 8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,18},
        {19,-1, 7, 5, 5, 6,-1, 7, 5, 5, 5, 6,-1, 9, 8,-1, 7, 5, 5, 5, 6,-1, 7, 5, 5, 6,-1,18},
        {19,-2, 9,46,46, 8,-1, 9,46,46,46, 8,-1, 9, 8,-1, 9,46,46,46, 8,-1, 9,46,46, 8,-2,18},
        {19,-1,41,30,30,40,-1,41,30,30,30,40,-1,11,10,-1,41,30,30,30,40,-1,41,30,30,40,-1,18},
        {19,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,18},
        {19,-1, 7, 5, 5, 6,-1, 7, 6,-1, 7, 5, 5, 5, 5, 5, 5, 6,-1, 7, 6,-1, 7, 5, 5, 6,-1,18},
        {19,-1,41,31,31,40,-1, 8, 9,-1,41,31,31, 6, 7,31,31,40,-1, 8, 9,-1,41,31,31,40,-1,18},
        {19,-1,-1,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1,-1,-1,18},
        {21,28,28,28,28, 6,-1, 8,41, 5, 5, 6,-3, 8, 9,-3, 7, 5, 5,10, 9,-1, 7,28,28,28,28,20},
        {46,46,46,46,46,19,-1, 8,39,31,31,40,-3,11,10,-3,41,31,31, 6, 9,-1,18,46,46,46,46,46},
        {46,46,46,46,46,19,-1, 8, 9,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3, 8, 9,-1,18,46,46,46,46,46},
        {46,46,46,46,46,19,-1, 8, 9,-3,13,29,29,29,29,29,29,12,-3, 8, 9,-1,18,46,46,46,46,46},
        {27,27,27,27,27,40,-1,11,10,-3,18,46,46,46,46,46,46,19,-3,11,10,-1,41,27,27,27,27,27},
        {-3,-3,-3,-3,-3,-3,-1,-3,-3,-3,18,46,46,46,46,46,46,19,-3,-3,-3,-1,-3,-3,-3,-3,-3,-3},
        {28,28,28,28,28, 6,-1, 7, 6,-3,18,46,46,46,46,46,46,19,-3, 7, 6,-1, 7,28,28,28,28,28},
        {46,46,46,46,46,19,-1, 8, 9,-3,15,27,27,27,27,27,27,14,-3, 8, 9,-1,18,46,46,46,46,46},
        {46,46,46,46,46,19,-1, 8, 9,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3, 8, 9,-1,18,46,46,46,46,46},
        {46,46,46,46,46,19,-1, 8, 9,-3, 7, 5, 5, 5, 5, 5, 5, 6,-3, 8, 9,-1,18,46,46,46,46,46},
        {17,27,27,27,27,40,-1,11,10,-3,41,31,31, 6, 7,31,31,40,-3,11,10,-1,41,27,27,27,27,16},
        {19,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,18},
        {19,-1, 7, 5, 5, 6,-1, 7, 5, 5, 5, 6,-1, 8, 9,-1, 7, 4, 4, 4, 6,-1, 7, 5, 5, 6,-1,18},
        {19,-1,41,31, 6, 9,-1,41,31,31,31,40,-1,11,10,-1,41,31,31,31,40,-1, 8, 7,31,40,-1,18},
        {19,-2,-1,-1, 8, 9,-1,-1,-1,-1,-1,-1,-1,-3,-3,-1,-1,-1,-1,-1,-1,-1, 8, 9,-1,-1,-2,18},
        {23,31, 6,-1, 8, 9,-1,39,38,-1, 7, 5, 5, 5, 5, 5, 5,38,-1,39,38,-1, 8, 9,-1, 7,31,22},
        {25, 5,40,-1,11,10,-1, 8, 9,-1,41,31,31, 6, 7,31,31,10,-1, 8, 9,-1,11,10,-1,41, 5,24},
        {19,-1,-1,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1, 8, 9,-1,-1,-1,-1,-1,-1,18},
        {19,-1, 7, 5, 5, 5, 5,10,11, 5, 5, 6,-1, 8, 9,-1, 7, 5, 5,10,11, 5, 5, 5, 5, 6,-1,18},
        {19,-1,41,31,31,31,31,31,31,31,31,40,-1,11,10,-1,41,31,31,31,31,31,31,31,31,40,-1,18},
        {19,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,18},
        {21,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,20},
    };

    int[,] currentMap = null;
	GameObject mapObj = null;
	GameObject mapPiece = null;
	public Sprite[] mapSprites; 
	public Sprite smallPoint,bigPoint,bigPoint1;
 
	public int[,] mapArray{
		get { return originalMap;}
	}

    public void InitMap() {
		if (this.gameObject != null) {
			mapObj = gameObject;
			mapPiece = mapObj.transform.Find ("MapPiece").gameObject;
			mapPiece.SetActive (true);
		}
        currentMap = originalMap;
		if(mapPiece != null && mapSprites!= null){
	        for (int i = 0; i <m_row ; i++)
	        {
	            for (int j = 0; j < m_column; j++)
	            {
					GameObject tPiece = GameObject.Instantiate (mapPiece, mapObj.transform).gameObject;
					tPiece.transform.localScale = Vector3.one;

					tPiece.transform.localPosition = new Vector3(j*47,i*(-47),0);
					tPiece.name = "m_" + i + "_" + j;
					if (currentMap [i, j] > 0) {
						tPiece.GetComponent<Image>().sprite = mapSprites [currentMap [i, j]];

					} else if (currentMap [i, j] == -1) {
						// pac-dots 
						tPiece.GetComponent<Image> ().sprite = smallPoint;
					} else if (currentMap [i, j] == -2) {
						// power pellet 
						tPiece.GetComponent<Image> ().sprite = bigPoint;
						SimpleAnimation tPowerBullet = tPiece.AddComponent<SimpleAnimation> ();
						tPowerBullet.aniSprites = new Sprite[3]{bigPoint, bigPoint1,smallPoint};
						tPowerBullet.playRat = 15;
						tPowerBullet.isLoop = true;
						tPowerBullet.isPingPang = true;
						tPowerBullet.Play ();


					} else if (currentMap [i, j] == -3) {
						//empty road
						tPiece.GetComponent<Image> ().sprite = mapSprites[46];
					}
				}
	        }
			mapPiece.SetActive (false);
		}
    }
	//set piece sprite to normal  
	public void SetDotsHide(int[,] pPos ){
		string tDotName = "m_"+pPos[0,1]+"_"+pPos[0,0];
		Image tDotsPiece = mapObj.transform.Find (tDotName).GetComponent<Image>();
		if (tDotsPiece.gameObject.GetComponent<SimpleAnimation> ()) {
			tDotsPiece.gameObject.GetComponent<SimpleAnimation> ().Stop ();
		}
		tDotsPiece.sprite = mapSprites [46];

	}

    
}
