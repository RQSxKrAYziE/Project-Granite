using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] readonly float destroyBelowY = -10;
    [SerializeField] bool respawnOnStart = false;

    void Start () {
        if (respawnOnStart)
        {
            Respawn.RespawnRandomSquare(gameObject);
        }
    }
	

    public void KillThisEnemy()
    {
        GetComponentInParent<DestructableObject>().ApplyDestruction();
        PlayerManager.enemiesPlayerKilled++;
    }
}
