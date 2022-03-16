using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float damage = 0.25f;
    public bool hasOwner = false;
    public bool isThrown = false;
    public GameObject thrownBy;
    
    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c)
    {
        PlayRandomHitSound();
        if (c.gameObject.layer == LayerMask.NameToLayer("Map")) // as soon as the ball touches the wall/floor/ceiling, it is a dead ball (no damage after that)
        {
            isThrown = false;
        }
        // upon hitting a AI/player, call the Player's PlayerController TakeDamage() function. Make sure the "colliding" ball wasn't thrown by the same person its colliding with
        else if (c.gameObject.layer == LayerMask.NameToLayer("Player") && isThrown == true && c.gameObject != thrownBy) 
        {
            PlayerController pc = c.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.TakeDamage(damage); // fixed damage for now
                isThrown = false; // eliminate taking damage twice before the ball hits the ground
            }

            EnemyController ec = c.gameObject.GetComponent<EnemyController>();
            if (ec != null)
            {
                ec.TakeDamage(damage); // fixed damage for now
                isThrown = false; // eliminate taking damage twice before the ball hits the ground
            }
        }
    }

    private void PlayRandomHitSound()
    {
        AudioClip randClip;
        if(rb.velocity.magnitude > loudSpeed){
            randClip = randomLoudAudioClip.GetRandomAudioClip();
        }
        else if (rb.velocity.magnitude > loudSpeed){
            randClip = randomMediumAudioClip.GetRandomAudioClip();
        } else {
            randClip = randomQuietAudioClip.GetRandomAudioClip();
        }
        
        // Debug.Log("Dodgeball hit, vel is "+rb.velocity.magnitude+", playing clip: "+randClip);
        audioSource.PlayOneShot(randClip);
    }
}
