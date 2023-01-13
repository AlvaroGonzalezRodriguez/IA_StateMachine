using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    public GameObject bullet;
    GameObject player;
    private float shootCooldown = 2.5f;
    private float lastShoot;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isChasing");
        player = GameObject.Find("FPSController");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.transform.position);
        if(distance > 15.0f)
            animator.SetTrigger("isChasing");

        if(animator.GetComponent<RobotHealth>().GetHealth() < 20.0f)
            animator.SetTrigger("isHiding");

        animator.transform.LookAt(player.transform.position);
        if(Time.time > lastShoot + shootCooldown)
        {
            GameObject b = Instantiate(bullet, animator.transform.position + animator.transform.forward * 2, animator.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(animator.transform.forward * 500);
            lastShoot = Time.time;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
