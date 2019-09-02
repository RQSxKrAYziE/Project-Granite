﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == Tags.PLAYER) {
            PlayerManager.doorKeys.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
}
