using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int health = 100;

    public void TakeDamage (int damage) {
        if (health - damage < 0) {
            health = 0;
        } else {
            health -= damage;
        }
    }
}