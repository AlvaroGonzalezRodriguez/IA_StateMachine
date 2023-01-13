using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : StateMachineBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject target;
	Vector3 wanderTarget = Vector3.zero;
    float visDist = 20.0f;
    float visAngle = 30.0f;
    //Drive ds;
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isHiding");
        target = GameObject.Find("FPSController");
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //ds = target.GetComponent<Drive>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = target.transform.position - animator.transform.position;
        float angle = Vector3.Angle(direction, animator.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle)
        
            //animator.SetFloat("distance", Vector3.Distance(animator.transform.position, target.transform.position));
            animator.SetTrigger("isChasing");
		
		float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = animator.gameObject.transform.InverseTransformVector(targetLocal);

        agent.SetDestination(targetWorld);
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
