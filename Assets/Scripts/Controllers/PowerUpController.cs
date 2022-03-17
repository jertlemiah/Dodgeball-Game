using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private Vector3 originalSpawn;
    // Start is called before the first frame update
    void Start()
    {
        originalSpawn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.layer == LayerMask.NameToLayer("Player")) {
            PlayerController pc = c.gameObject.GetComponent<PlayerController>();
            if (pc != null) { // Should I check if there is already a powerup so we can't get multiple?
                pc.AddPowerup(gameObject);
            }
            gameObject.transform.position = new Vector3(-30, -30, -30);
            StartCoroutine(Coundownspawn());
        }
    }

    IEnumerator Coundownspawn()
    {
        yield return new WaitForSeconds(10f);
        gameObject.transform.position = originalSpawn;
    }
}
