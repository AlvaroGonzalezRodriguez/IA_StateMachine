using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Persue : StateMachineBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject target;
    FirstPersonController fpsCont;
    float visDist = 20.0f;
    float visAngle = 30.0f;
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isPatrol");
        animator.ResetTrigger("isShooting");
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.Find("FPSController");
        fpsCont = target.GetComponent<FirstPersonController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, target.transform.position);
        if(distance < 10.0f)
            animator.SetTrigger("isShooting");
        
        Vector3 direction = target.transform.position - animator.transform.position;
        float angle = Vector3.Angle(direction, animator.transform.forward);
        if (direction.magnitude > visDist && angle < visAngle)
            animator.SetTrigger("isPatrol");

        /*Vector3 targetDir = target.transform.position - animator.transform.position;

        float lookAhead = targetDir.magnitude * fpsCont.currentSpeed / agent.speed;
        Debug.DrawRay(target.transform.position, target.transform.forward * lookAhead,Color.red);*/
        //agent.SetDestination(target.transform.position + target.transform.forward * lookAhead);
        agent.SetDestination(target.transform.position);
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
