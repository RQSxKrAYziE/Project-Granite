using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    
    [Header("Health:")]
    [SerializeField]
    RectTransform healthFill;

    [SerializeField]
    List<Image> Keys = new List<Image>();

    private void Update() {
        SetHealthAmount(PlayerManager.health/PlayerManager.maxHealth);
        GetKeyImages();
    }

    void SetHealthAmount(float amount) {
        healthFill.localScale = new Vector3(amount, 1, 1);
    }

    void GetKeyImages() {
        Debug.Log("");
    }
}