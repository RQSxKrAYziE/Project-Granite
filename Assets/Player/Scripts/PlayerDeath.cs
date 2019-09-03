using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] GameObject deathScreen;
    [SerializeField] float health = 50;

    [SerializeField] Text timeAlive;
    [SerializeField] Text kills;
    [SerializeField] Text punches;
    [SerializeField] Text punchEfficancy;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            PlayerManager.alive = true;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void DamagePlayer(float damage) {
        health = health - damage;
        CheckHealth();
    }

    void CheckHealth() { 
        if(health <= 0) {
            killPlayer();
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

    