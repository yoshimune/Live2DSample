using UnityEngine;
using System.Collections;
using Novel;


public class PlaneEvent : MonoBehaviour {

	//	private	GameManager gameManager;

	// Use this for initialization
	void Start () {

		//	this.gameManager = NovelSingleton.GameManager;
	
	}

	// Update is called once per frame
	void Update () {
    	
		//スキップ中なら一定時間毎にNextOrder を行う

	
	}

	void OnMouseDown(){

	}

	void OnMouseUp(){

		/*
		return ;

		Debug.Log ("PLANE EVENT");

		if (StatusManager.inUiClick == true) {
			StatusManager.inUiClick = false;
			return;
		}

		GameManager gameManager = NovelSingleton.GameManager;

		//skip中にクリックされた場合、Skipを止める
		if (StatusManager.FlagSkiiping == true) {
			StatusManager.FlagSkiiping = false;
		}

		//Auto中にクリックされた場合、Autoを止める
		if (StatusManager.FlagAuto == true) {
			StatusManager.FlagAuto = false;
		}

		//ステータスマネージャみたいなの持たせてもいいよね
		if (StatusManager.isMessageShowing == true) {
			//速度を上げる
			gameManager.scene.MessageSpeed = 0.001f;
			return;
		}

		if (StatusManager.enableClickOrder == true) {


			gameManager.clickNextOrder ();

		}

*/


	}

}


