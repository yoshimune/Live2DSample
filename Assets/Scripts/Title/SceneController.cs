using UnityEngine;
using System.Collections;
using Novel;

public class SceneController : MonoBehaviour {

    public TextController textController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void tweet()
    {
        Twitter.Tweet ("のぞみを" + textController.getguriTime().ToString("F3") + "秒間グリグリしました " + "https://hidden-lowlands-3945.herokuapp.com/");
    }

     public void startNovel() 
    {
        NovelSingleton.StatusManager.callJoker ("wide/scene2", "");
    }
}
