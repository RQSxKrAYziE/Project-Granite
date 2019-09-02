using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Respawn {

    public static void RespawnRandomSquare(GameObject obj, float respawnRange = 20)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = new Vector3(
            Random.Range(-respawnRange, respawnRange),
            0,
            Random.Range(-respawnRange, respawnRange)
            );

        //obj.GetComponent<Collider>().enabled = true;

        //obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //obj.GetComponent<Collider>().enabled = true;
    }
}
