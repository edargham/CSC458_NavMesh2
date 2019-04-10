using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour {

    private float radius = 10, smallRadius = 4;
    private GameObject player;
    private NavMeshAgent agent;
    private Animator animator;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Sqrt((player.transform.position-transform.position).sqrMagnitude)<radius)
        {
            agent.SetDestination(player.transform.position);

            if(Mathf.Sqrt((player.transform.position - transform.position).sqrMagnitude) < smallRadius)
            {
                transform.LookAt(player.transform);
            }
        }
        animator.SetFloat("Speed", Mathf.Sqrt((agent.velocity.sqrMagnitude)));
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smallRadius);
    }
}
