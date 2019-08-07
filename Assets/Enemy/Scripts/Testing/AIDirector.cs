using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDirector : MonoBehaviour {
    /*
    [SerializeField] Transform player;
    [SerializeField] List<EnemyAI> all = new List<EnemyAI>();
    List<EnemyAI> close = new List<EnemyAI>();
    List<EnemyAI> far = new List<EnemyAI>();

    int closeCycle = 10;
    int cl;
    int farCycle = 30;
    int fr;

    float maxDistance = 5;

    private void Start() {
        EnemyAI[] a = GameObject.FindObjectsOfType<EnemyAI>();
        all.AddRange(a);
        for (int i = 0; i < all.Count ; i++) {
            float distance = Vector3.Distance(player.position, all[i].transform.position);
            if (distance < maxDistance)
                close.Add(all[i]);
            else
                far.Add(all[i]);
            all[i].playerTarget = player;
        }
    }

    private void Update() {
        cl++;
        fr++;
        if (cl > closeCycle) {
            cl = 0;
            for(int i = 0; i < close.Count; i++) {
                //close[i].RotateEnemy();
            }
        }
        if (fr > farCycle) {
            fr = 0;
            for(int i = 0; i < far.Count; i++) {
                //far[i].RotateEnemy();
            }
        }
    }*/
}
