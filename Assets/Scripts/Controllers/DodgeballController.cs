using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DodgeballType {none, Dodgeball, Fastball, Deathball, Heavyball}
public class DodgeballController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [Header("Audio Things")]
    [SerializeField] AudioClip[] dodgeballClipsQuiet;
    [SerializeField] AudioClip[] dodgeballClipsMedium;
    [SerializeField] AudioClip[] dodgeballClipsLoud;
    [SerializeField] AudioSource audioSource;  
    // [SerializeField] float quietSpeed = 0.1f;
    // [SerializeField] float mediumSpeed = 0.2f;
    [SerializeField] float loudSpeed = 0.3f;
    RandomAudioClip randomQuietAudioClip = new RandomAudioClip();
    RandomAudioClip randomMediumAudioClip = new RandomAudioClip();
    RandomAudioClip randomLoudAudioClip = new RandomAudioClip();
    public float velocity = 20f;
    public float damage = 2.0f;
    public bool hasOwner = false;
    public bool isThrown = false;
    public GameObject thrownBy;

    private UnityEngine.Vector3 spawnPoint;

    private bool ballRespawnRunning = false;
    public DodgeballType dodgeballType = DodgeballType.Dodgeball;
    
    // Start is called before the first frame update
    public void Start()
    {
        if(dodgeballClipsQuiet.Length > 0)
            randomQuietAudioClip.audioClipArray = dodgeballClipsQuiet;
        if(dodgeballClipsMedium.Length > 0)
            randomMediumAudioClip.audioClipArray = dodgeballClipsMedium;
        if(dodgeballClipsLoud.Length > 0)
            randomLoudAudioClip.audioClipArray = dodgeballClipsLoud;
        
        if(!audioSource)
            audioSource = GetComponent<AudioSource>();
        if(!rb)
            rb = GetComponent<Rigidbody>();

        spawnPoint = transform.position;
    }

    public void PickupByPlayer(UnitController unitController)
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (isThrown && !ballRespawnRunning) {
            StartCoroutine(CountdownBallRespawn());
        }
    }
    void OnCollisionEnter(Collision c)
    {
        PlayRandomHitSound();
        if (c.gameObject.layer == LayerMask.NameToLayer("Map")) // as soon as the ball touches the wall/floor/ceiling, it is a dead ball (no damage after that)
        {
            isThrown = false;
        }
        // upon hitting a AI/player, call the Player's UnitController TakeDamage() function. Make sure the "colliding" ball wasn't thrown by the same person its colliding with
        else if (c.gameObject.layer == LayerMask.NameToLayer("Player") && isThrown == true && c.gameObject != thrownBy) 
        {
            UnitController unit = c.gameObject.GetComponent<UnitController>();
            if (unit != null)
            {
                unit.TakeDamage(damage);
                isThrown = false; // eliminate taking damage twice before the ball hits the ground
            }
        }
    }

    private void PlayRandomHitSound()
    {
        AudioClip randClip;
        if(rb.velocity.magnitude > loudSpeed & randomLoudAudioClip.audioClipArray.Length>0){
            randClip = randomLoudAudioClip.GetRandomAudioClip();
        }
        else if (rb.velocity.magnitude > loudSpeed  & randomMediumAudioClip.audioClipArray.Length>0){
            randClip = randomMediumAudioClip.GetRandomAudioClip();
        } else if(randomQuietAudioClip.audioClipArray.Length>0) {
            randClip = randomQuietAudioClip.GetRandomAudioClip();
        } else {
            Debug.Log("No appropriate sounds were assigned for this object: "+gameObject.name);
            return;
        }
        
        // Debug.Log("Dodgeball hit, vel is "+rb.velocity.magnitude+", playing clip: "+randClip);
        audioSource.PlayOneShot(randClip);
    }

        IEnumerator CountdownBallRespawn()
    {
        ballRespawnRunning = true;
        UnityEngine.Debug.Log("CountdownBallRespawn");
        yield return new WaitForSeconds(10f);
        if (hasOwner == false)
        {
            UnityEngine.Debug.Log("Moving to spawn");
            transform.position = spawnPoint;
        }
        ballRespawnRunning = false;
    }
}
