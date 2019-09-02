using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public void CheckKey(GameObject key, GameObject button) {
        if (PlayerManager.doorKeys.Contains(key)) {
            CheckInteract(key, button);
        } else {
            Debug.Log("Need " + key);
        }
    }

    void CheckInteract(GameObject key, GameObject button) {
        if (Input.GetKeyDown(KeyCode.E)) {
            button.GetComponent<DoorButtons>().hasKey = true;
            button.GetComponent<Collider>().enabled = false;
        }
    }
}
