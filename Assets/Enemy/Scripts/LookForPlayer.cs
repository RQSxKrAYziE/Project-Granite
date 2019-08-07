using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : MonoBehaviour {
    #region Singleton

    public static LookForPlayer instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;


}
