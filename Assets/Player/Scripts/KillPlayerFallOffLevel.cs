using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerFallOffLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerManager.player.transform.position.y < -13 && PlayerManager.alive)
        {
            PlayerManager.playerDeath.killPlayer();
        }
	}
}
