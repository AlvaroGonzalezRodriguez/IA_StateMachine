using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : StateMachineBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject target;
    RobotHealth rHealth;
    private float healthCooldown = 1.0f;
    private float lastHealth;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("isShooting");
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.Find("FPSController");
        rHealth = animator.GetComponent<RobotHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*float dist = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;

        if(CanSeeTarget(animator))
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Hide").Length; i++)
            {
                Vector3 hideDir = GameObject.FindGameObjectsWithTag("Hide")[i].transform.position - target.transform.position;
                Vector3 hidePos = GameObject.FindGameObjectsWithTag("Hide")[i].transform.position + hideDir.normalized * 10;

                if (Vector3.Distance(animator.transform.position, hidePos) < dist)
                {
                    chosenSpot = hidePos;
                    dist = Vector3.Distance(animator.transform.position, hidePos);
                }
            }

            agent.SetDestination(chosenSpot);
        }*/
		
		float dist = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;
        Vector3 chosenDir = Vector3.zero;
        GameObject chosenGO = GameObject.FindGameObjectsWithTag("Hide")[0];
		if(CanSeeTarget(animator))
		{
			for (int i = 0; i < GameObject.FindGameObjectsWithTag("Hide").Length; i++)
			{
				Vector3 hideDir = GameObject.FindGameObjectsWithTag("Hide")[i].transform.position - target.transform.position;
				hideDir.y = 0.0f;
				Vector3 hidePos = GameObject.FindGameObjectsWithTag("Hide")[i].transform.position + hideDir.normalized * 100;
				

				if (Vector3.Distance(animator.transform.position, hidePos) < dist)
				{
					chosenSpot = hidePos;
					chosenDir = hideDir;
					chosenGO = GameObject.FindGameObjectsWithTag("Hide")[i];
					dist = Vector3.Distance(animator.transform.position, hidePos);
				}
			}

			Collider hideCol = chosenGO.GetComponent<Collider>();
			Ray backRay = new Ray(chosenSpot, -chosenDir.normalized);
			RaycastHit info;
			float distance = 250.0f;
			hideCol.Raycast(backRay, out info, distance);
			Debug.DrawRay(chosenSpot, -chosenDir.normalized * distance, Color.red);
			
			agent.SetDestination(info.point + chosenDir.normalized);
		}
        else if (Time.time > lastHealth + healthCooldown)
        {
            rHealth.AddHealth();
            lastHealth = Time.time;
        }

        if(rHealth.GetHealth() >= 100.0f)
        {
            animator.SetTrigger("isPatrol");
        }
        
    }

    bool CanSeeTarget(Animator animator)
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - animator.transform.position;
        if (Physics.Raycast(animator.transform.position, rayToTarget, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject.name == "FPSController"){
				Debug.Log("Veo");
				return true;
			}
        }
		Debug.Log("No veo");
        return false;
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
