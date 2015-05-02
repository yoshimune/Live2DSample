using UnityEngine;
using System.Collections;

public static class Twitter {
    public static void Tweet (string text)
    {
        if (Application.platform == RuntimePlatform.WindowsWebPlayer 
            || Application.platform == RuntimePlatform.OSXWebPlayer) {
            //Application.OpenURL ("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL (text));
            Application.ExternalEval ("var F = 0;if (screen.height > 500) {F = Math.round((screen.height / 2) - (250));}window.open('" + "http://twitter.com/intent/tweet?text=" + WWW.EscapeURL (text) + "','intent','left='+Math.round((screen.width/2)-(250))+',top='+F+',width=500,height=260,personalbar=no,toolbar=no,resizable=no,scrollbars=yes');");
        } else {
            Debug.Log ("WebPlayer以外では実行できません。");
        }
    }
}
