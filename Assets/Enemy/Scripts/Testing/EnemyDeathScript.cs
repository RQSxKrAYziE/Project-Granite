using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeathScript : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] Transform ragdoll;
    [SerializeField] float force;
    private NavMeshAgent agent;
    private Vector3 direction;
    private bool hit;
    private bool grounded = false;
    public int health = 50;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public IEnumerator DealDamage(int damage) {
        hit = true;
        agent.enabled = false;
        direction = player.position - transform.position;
        direction = -direction.normalized;
        GetComponent<Rigidbody>().AddForce(direction.x * force, force / 2, direction.z * force);
        Debug.Log("Attack");
        health = health - damage;
        CheckHealth();
        yield return new WaitUntil(() => grounded == true);
        hit = false;
    }

    private void CheckHealth() {
        if (health <= 0) {
            PlayerManager.enemiesPlayerKilled++;
            Ragdoll();
            //Destroy(gameObject);
        }
    }

    void Ragdoll() {

    }

    private void OnCollisionExit(Collision collision) {
        grounded = false;
    }

    private void OnCollisionStay(Collision collision) {
        grounded = true;
        if (hit)
            return;
        else
            agent.enabled = true;
    }
}
