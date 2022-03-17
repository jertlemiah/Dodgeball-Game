using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalHealth = 100;
    public int currentHealth = 100;
    private SpawnManager spawnManager;
    public Vector3 spawnPos = new Vector3(0,0,0);
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = false;
            }
            var spawnPoint = spawnManager.GetSpawnLocation();
            Debug.Log("spawnPoint" + spawnPoint);
            player.transform.position = spawnPoint;
            totalHealth = 100;
            currentHealth = 100;
            StartCoroutine(CoundownDeath());
        }
        
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(gameObject.name+" has been hit by "+c.gameObject.name);
    }

    public void TakeDamage (int damage) {
        if (currentHealth - damage < 0) {
            currentHealth = 0;
        } else {
            currentHealth -= damage;
        }
    }

    IEnumerator CoundownDeath()
    {
        yield return new WaitForSeconds(5f);
        if (player.GetComponent<CharacterController>() != null)
        {
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
