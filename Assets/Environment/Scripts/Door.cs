using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] List<GameObject> buttons = new List<GameObject>();

    private void Update() {
        CheckButtons();
    }

    void CheckButtons() {
        buttons.TrueForAll(HasButton);
    }

    static bool HasButton(GameObject g) {
        return g.GetComponent<DoorButtons>().hasKey = true;
    }
}
