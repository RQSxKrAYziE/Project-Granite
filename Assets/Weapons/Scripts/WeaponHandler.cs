using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    ONE_HANDED,
    TWO_HANDED
}

public class WeaponHandler : MonoBehaviour {

    private Rigidbody rb;
    public Vector3 holdPosition;
    public Vector3 holdRotation;
    public int damage;
    public bool throwable;
    public WeaponType weaponType;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == Tags.ENEMY) {
            collision.gameObject.GetComponent<EnemyDeathScript>().DealDamage(damage);
        }
    }

    private void OnCollisionStay(Collision collision) {
        StartCoroutine(ResetWeapon());
    }

    public IEnumerator ThrowWeapon() {
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        yield return new WaitForSeconds(0.05f);
        transform.GetChild(1).GetComponent<Collider>().enabled = true;
    }
    
    IEnumerator ResetWeapon() {
        yield return new WaitForSeconds(1);
        rb.useGravity = false;
        var pos = transform.position;
        pos.y = 1.6f;
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

}
