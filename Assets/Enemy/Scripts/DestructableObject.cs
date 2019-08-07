using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

    [SerializeField] GameObject destroyedPrefab;
    [SerializeField] float respawnBelowY = -10;

    GameObject destroyedParts;
    GameObject normalState;
    bool destroyed = false;

    private void Start()
    {
        normalState = gameObject.transform.GetChild(0).gameObject;
    }

    void Update () {
        
        if (destroyed && 
            destroyedParts.transform.GetChild(0).position.y < respawnBelowY)
        {
            Respawn.RespawnRandomSquare(gameObject);
            ResetDestruction();
        }
    }

    public void ResetDestruction()
    {
        destroyed = false;
        normalState.SetActive(true);
        Destroy(destroyedParts);
    }

    public void ApplyDestruction()
    {
        destroyed = true;
        normalState.SetActive(false);
        destroyedParts = Instantiate(destroyedPrefab);
        destroyedParts.SetActive(true);
        destroyedParts.transform.position = normalState.transform.position;
        destroyedParts.transform.rotation = normalState.transform.rotation;
        for (int i = 0; i < destroyedParts.transform.childCount; i++)
        {
            destroyedParts.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().AddForce(PlayerManager.player.transform.forward *500);
        }
    }
}
