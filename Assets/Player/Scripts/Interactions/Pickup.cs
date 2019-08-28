using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    
    private Attack attackScript;
    WeaponHandler carriedHandler;
    Transform throwHand;
    GameObject throwWeapon; 
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] float startThrowHold = 0.0f;
    [SerializeField] float throwHoldTimer = 1.0f;
    public GameObject rightHandWeapon;
    public GameObject leftHandWeapon;

    private void Awake() {
        attackScript = GetComponent<Attack>();
    }

    private void Update() {
        if (!PlayerManager.alive) { return; }
        if (rightHandWeapon != null || leftHandWeapon != null) {
            CheckThrow();
        }
    }
    
    void ThrowObject() {
        StartCoroutine(throwWeapon.GetComponent<WeaponHandler>().ThrowWeapon());
        throwWeapon.transform.parent = null;
        ChangeLayerRecursively(throwWeapon.transform, Layers.DEFAULT);
        throwWeapon.GetComponent<Rigidbody>().AddForce(throwHand.forward * 1000);
    }//throw object

    void Drop(GameObject weapon) {
        weapon.transform.parent = null;
        ChangeLayerRecursively(weapon.transform, Layers.DEFAULT);
        weapon.GetComponent<Rigidbody>().useGravity = true;
        attackScript.ResetDamage();
        leftHandWeapon = null;
        rightHandWeapon = null;
    }//Drop

    void CheckThrow() {
        //--------------------------LEFT HAND THROW-------------------------------\\
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            startThrowHold = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (leftHandWeapon == null) { return; }
            if (startThrowHold + throwHoldTimer <= Time.time) {
                if (leftHandWeapon.GetComponent<WeaponHandler>().throwable) {
                    throwHand = leftHand;
                    throwWeapon = leftHandWeapon;
                    leftHandWeapon = null;
                    attackScript.leftDamage = attackScript.fistDamage;
                    GetComponent<Animator>().SetTrigger(PlayerAnimation.LEFT_THROW);
                } else {
                    Drop(leftHandWeapon);
                }
            }
        }
        //--------------------------RIGHT HAND THROW-------------------------------\\
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            startThrowHold = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse1)) {
            if (rightHandWeapon == null) { return; }
            if (startThrowHold + throwHoldTimer <= Time.time) {
                if (rightHandWeapon.GetComponent<WeaponHandler>().throwable) {
                    throwHand = rightHand;
                    throwWeapon = rightHandWeapon;
                    rightHandWeapon = null;
                    attackScript.rightDamage = attackScript.fistDamage;
                    GetComponent<Animator>().SetTrigger(PlayerAnimation.RIGHT_THROW);
                } else {
                    Drop(rightHandWeapon);
                }
            }
        }
    }//Check throw

    public void PickUpObject(GameObject weapon) {
        carriedHandler = weapon.GetComponent<WeaponHandler>();
        weapon.transform.GetChild(1).GetComponent<Collider>().enabled = false;
        switch (carriedHandler.weaponType) {
            case WeaponType.TWO_HANDED:
                rightHandWeapon = weapon;
                leftHandWeapon = weapon;
                weapon.transform.parent = rightHand;
                attackScript.rightDamage = attackScript.leftDamage = carriedHandler.damage;
                weapon.transform.localPosition = carriedHandler.holdPosition;
                weapon.transform.localEulerAngles = carriedHandler.holdRotation;
                weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                ChangeLayerRecursively(weapon.transform, Layers.FPS);
                break;
            case WeaponType.ONE_HANDED:
                if(rightHandWeapon == null) {
                    weapon.transform.parent = rightHand;
                    rightHandWeapon = weapon;
                    attackScript.rightDamage = carriedHandler.damage;
                } else {
                    weapon.transform.parent = leftHand;
                    leftHandWeapon = weapon;
                    attackScript.leftDamage = carriedHandler.damage;
                }
                weapon.GetComponent<BoxCollider>().enabled = false;
                weapon.transform.localPosition = carriedHandler.holdPosition;
                weapon.transform.localEulerAngles = carriedHandler.holdRotation;
                weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                ChangeLayerRecursively(weapon.transform, Layers.FPS);
                break;
        }
    }//Pickup Object

    void ChangeLayerRecursively(Transform trans, string layerName) {
        //Changes the layer of the weapon and all child objects
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
            ChangeLayerRecursively(child, layerName);
    }//Change Layer
}//class