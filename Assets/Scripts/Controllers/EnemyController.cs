using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    private SpawnManager spawnManager;
    public Vector3 spawnPos = new Vector3(0,0,0);
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = false;
            }
            var spawnPoint = spawnManager.GetSpawnLocation();
            Debug.Log("spawnPoint" + spawnPoint);
            player.transform.position = spawnPoint;
            health = 100;
            StartCoroutine(Coundowndeath());
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = true;
            }
        }
        
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(gameObject.name+" has been hit by "+c.gameObject.name);
    }

    public void TakeDamage (int damage) {
        if (health - damage < 0) {
            health = 0;
        } else {
            health -= damage;
        }
    }

    IEnumerator Coundowndeath()
    {
      yield return new WaitForSeconds(5f);
    }
}
