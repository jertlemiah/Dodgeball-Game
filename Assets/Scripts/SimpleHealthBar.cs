using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    public Slider healthBar;
    private int playerHealth;

    void Start() {
         playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;
         healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    // TODO: We probably dont want this updating every tick, but for now its fine
    void Update() {
         healthBar.value = playerHealth;
    }
}
