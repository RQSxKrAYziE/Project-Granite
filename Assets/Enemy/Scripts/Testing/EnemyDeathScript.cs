using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour {

    public int health = 50;

    public void DealDamage(int damage) {
        health = health - damage;
        CheckHealth();
    }

    private void CheckHealth() {
        if (health <= 0)
            Destroy(gameObject);
    }
}
