using UnityEngine;
using System.Collections;
using Novel;

public class ScriptController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void clickButton () {
        Debug.Log("click buttom");

        NovelSingleton.StatusManager.callJoker ("wide/scene1","");
    }
}
