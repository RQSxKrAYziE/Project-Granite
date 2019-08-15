using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Pickup pickupScript;
    private PlayerMovement movementScript;
    private float attackDist = 3;
    [SerializeField] private Camera MainCamera;
    public int fistDamage;
    public int rightDamage;
    public int leftDamage;

	void Awake () {
        pickupScript = GetComponent<Pickup>();
        movementScript = GetComponent<PlayerMovement>();
        rightDamage = leftDamage = fistDamage;
	}
	
	void Update () {
        if(!PlayerManager.alive) { return; }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {//Left Click
            if (movementScript.dashing) {
                StartCoroutine(DashPunch(leftDamage * 2));
            } else {
                GetComponent<Animator>().SetTrigger(Animation.LEFT_PUNCH);
                AttackEnemy(leftDamage);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {//RightClick
            if (movementScript.dashing) {
                StartCoroutine(DashPunch(rightDamage * 2));
            } else {
                GetComponent<Animator>().SetTrigger(Animation.RIGHT_PUNCH);
                AttackEnemy(rightDamage);
            }
        }
	}

    public void ResetDamage() {
        rightDamage = leftDamage = fistDamage;
    }

    void AttackEnemy(int damage) {
        float x = Screen.width / 2;
        float y = Screen.height / 2;
        Ray ray = MainCamera.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) {
            if (hit.distance <= attackDist) {
                if (hit.collider.tag == Tags.ENEMY) {
                    hit.collider.gameObject.GetComponent<EnemyDeathScript>().DealDamage(damage);
                }
            }
        }
    }

    IEnumerator DashPunch(int damage) {
        yield return new WaitUntil(() => movementScript.dashing == false);
        Debug.Log("Dash Punch");
    }
}
