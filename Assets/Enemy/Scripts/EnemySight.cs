using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour {

    [SerializeField] float fieldOfViewAngle = 110f;
    [SerializeField] bool playerInSight;
    [SerializeField] Vector3 personalLastSighting;
    private SphereCollider col;
    private GameObject player;
    private NavMeshAgent agent;

    private void Awake() {
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject == player) { //Searches for player gameobject
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle < fieldOfViewAngle * 0.5f) { //Checks if player is in field of view of the enemy
                RaycastHit hit;
                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)) { //shoots raycast out
                    if (hit.collider.gameObject == player) { //if raycast hits player 
                        playerInSight = true;
                        transform.LookAt(player.transform);
                        Vector3 movement = transform.forward * Time.deltaTime;
                        agent.Move(movement);
                        //agent.SetDestination(player.transform.position);
                        Debug.Log("Player Spotted");
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q)) { 
            //Just a quick way to "Emit sound" for the enemy to pick up.
                if (CalculatePathLength(player.transform.position) <= col.radius) {
                //if the players distance is less than the colliders radius.
                    playerInSight = true;
                    agent.SetDestination(player.transform.position);
                    Debug.Log("Player Heard");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player)
            playerInSight = false;
    }

    float CalculatePathLength(Vector3 targetPosition) {
        //Using the nav mesh, this calculates the distance from the player and the enemy.
        //If the player is behind a wall creates enough points to get around the nav mesh.
        NavMeshPath path = new NavMeshPath();
        if (agent.enabled)
            agent.CalculatePath(targetPosition, path);
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;
        for (int i = 0; i < path.corners.Length; i++) {
            allWayPoints[i + 1] = path.corners[i];
        }
        float pathLength = 0;
        for(int i = 0; i < allWayPoints.Length - 1; i++) {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        return pathLength;
        //sends calculated length between player and enemy.
    }
}
