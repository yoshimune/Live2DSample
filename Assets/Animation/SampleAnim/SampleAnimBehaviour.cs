using UnityEngine;
using System.Collections;

public class SampleAnimBehaviour : StateMachineBehaviour {


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log ("animator:" + animator.ToString());
        Debug.Log ("stateInfo:" + stateInfo.ToString());
        Debug.Log ("layerIndex:" + layerIndex.ToString());
    }
     
    override public void OnStateMove (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log ("OnStateMove");

    }

    override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log ("OnStateExit");
    }

    override public void OnStateIK (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log ("OnStateIK");
    }


}
