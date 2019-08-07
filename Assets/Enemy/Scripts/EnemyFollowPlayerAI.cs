using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayerAI : MonoBehaviour {
    
    [SerializeField] float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        target = PlayerManager.player.transform;
        agent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) {
                //Attack the Target
                //FaceTarget();
            }
        }
	}
    
    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
