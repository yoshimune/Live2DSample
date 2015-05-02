using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text guriText;
    private float guriTime;
	// Use this for initialization
	void Start () {
        guriTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            guriTime += Time.deltaTime;
            guriText.text = guriTime.ToString("F3") + "秒";
        }
	}

    public float getguriTime()
    {
        return guriTime;
    }
}
