using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    public Slider healthBar;
    PlayerHealth playerHealth;

    void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    void Update() {
        Debug.Log(healthBar.value.ToString());
        Debug.Log(playerHealth.health.ToString());
        healthBar.value = playerHealth.health;
    }
}
