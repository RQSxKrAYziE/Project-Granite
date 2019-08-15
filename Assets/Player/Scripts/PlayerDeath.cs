using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] GameObject deathScreen;

    [SerializeField] Text timeAlive;
    [SerializeField] Text kills;
    [SerializeField] Text punches;
    [SerializeField] Text punchEfficancy;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            respawnPlayer();
        }
    }


    public void killPlayer()
    {
        PlayerManager.alive = false;
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //set stats
        timeAlive.text = "Seconds Survived: " + PlayerManager.SecondsPlayerAlive;
        kills.text = "Things you punched: " + PlayerManager.enemiesPlayerKilled;
        //punches.text = "Times you punched: " + PlayerManager.timesPlayerPunched;
        //punchEfficancy.text = "Punch Efficancy Rating: " + (float)  PlayerManager.enemiesPlayerKilled / PlayerManager.timesPlayerPunched * 100 + "%";

        PlayerManager.ResetStats();
    }

    public void respawnPlayer()
    {
        PlayerManager.alive = true;
        deathScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerManager.player.transform.position = PlayerManager.respawnPoint;
        PlayerManager.player.GetComponent<Rigidbody>().velocity = new Vector3();
    }
}
