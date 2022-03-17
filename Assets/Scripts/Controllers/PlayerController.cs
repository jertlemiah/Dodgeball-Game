using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    public int health = 100;

    private SpawnManager spawnManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = SpawnManager.Instance;
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {   
        if (health <= 0) {
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = false;
            }
            var spawnPoint = spawnManager.GetSpawnLocation();
            Debug.Log("spawnPoint" + spawnPoint);
            player.transform.position = spawnPoint;
            health = maxHealth;
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = true;
            }
        }
    }

    public void TakeDamage (int damage) {
        if (health - damage < 0) {
            health = 0;
        } else {
            health -= damage;
        }
    }
}
