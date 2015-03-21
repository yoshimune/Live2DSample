using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {


     public TextMesh textMesh;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown (0)) {
            iTween.ValueTo (this.gameObject, iTween.Hash (
                "from", 0f,
                "to",  1.0f,
                "time", 1.0,
                "onUpdate", "UpdateScoreDisplay"
            ));
        } else if (Input.GetMouseButtonUp(0)) {
            iTween.Stop(gameObject);
        }
	}

    void UpdateScoreDisplay(float newScore){
        Debug.Log (newScore);
        textMesh.text = newScore.ToString();
    }
}
