using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int totalHealth = 100;
    public int currentHealth = 100;

    private SpawnManager spawnManager;
    public GameObject player;

    private GameObject powerup;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = SpawnManager.Instance;
        currentHealth = totalHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {   
        if (currentHealth <= 0) {
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = false;
            }
            var spawnPoint = spawnManager.GetSpawnLocation(player.transform.position);
            Debug.Log("spawnPoint" + spawnPoint);
            player.transform.position = spawnPoint;
            totalHealth = 100;
            currentHealth = 100;
            StartCoroutine(CoundownDeath());
        }
    }

    public void TakeDamage (int damage) {
        if (currentHealth - damage < 0) {
            currentHealth = 0;
        } else {
            currentHealth -= damage;
        }
    }

    public void AddPowerup(GameObject newPowerup) {
        powerup = newPowerup;
        if (powerup.name.Contains("Health")) {
            Debug.Log("Picked up Health");
            currentHealth += 25;
            if (currentHealth > totalHealth) {
                currentHealth = totalHealth;
            }
            powerup = null;
        } else if (powerup.name.Contains("Armor")) {
            Debug.Log("Picked up Armor");
            totalHealth += 50;
            currentHealth += 50;
            StartCoroutine(CoundownArmor());
        } else if (powerup.name.Contains("Speed")) {
            Debug.Log("Picked up Speed");
            rb.velocity = rb.velocity * 2;
            StartCoroutine(CoundownArmor());
        }
        Debug.Log("Player just collected new powerup: " + powerup);
    }

    IEnumerator CoundownDeath()
    {
        yield return new WaitForSeconds(5f);
        if (player.GetComponent<CharacterController>() != null)
        {
            player.GetComponent<CharacterController>().enabled = true;
        }
    }


    IEnumerator CoundownArmor()
    {
        yield return new WaitForSeconds(30f);
        totalHealth -= 50;
        if (currentHealth > totalHealth) {
            currentHealth = totalHealth;
        }
        powerup = null;
    }

    IEnumerator CoundownSpeed()
    {
        yield return new WaitForSeconds(30f);
        rb.velocity = rb.velocity / 2;
        powerup = null;
    }
}
