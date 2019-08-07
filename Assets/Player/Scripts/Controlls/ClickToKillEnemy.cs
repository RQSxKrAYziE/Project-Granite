using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKillEnemy : MonoBehaviour {

    //this script is made obsolete by ClickToMelleAttack

    [SerializeField] float maxRange;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.DrawRay(PlayerManager.camera.transform.position, transform.forward * 10,Color.green,0,false);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            PlayerManager.playerAnimations.playAnimation("Attack");

            if (Physics.Raycast(PlayerManager.camera.transform.position, transform.forward, out hit) &&
                hit.distance < maxRange &&
                hit.transform.gameObject.GetComponent<Enemy>())
            {
                hit.transform.gameObject.GetComponent<Enemy>().KillThisEnemy();
            }
        }
	}
}
