using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Pickup pickupScript;
    private float attackDist = 3;
    [SerializeField] private Camera MainCamera;
    public int fistDamage;
    public int rightDamage;
    public int leftDamage;

	void Awake () {
        pickupScript = GetComponent<Pickup>();
        rightDamage = leftDamage = fistDamage;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //Left Click
            AttackEnemy(leftDamage);
        if (Input.GetKeyDown(KeyCode.Mouse1)) //RightClick
            AttackEnemy(rightDamage);
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
}
