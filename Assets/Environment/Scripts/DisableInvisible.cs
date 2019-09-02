using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInvisible : MonoBehaviour
{
    [SerializeField] Light lightDisable;
    [SerializeField] Light lightEnable;


    private void OnTriggerEnter(Collider other)
    {
        lightDisable.enabled = false;
        lightEnable.enabled = true;
    }
}
