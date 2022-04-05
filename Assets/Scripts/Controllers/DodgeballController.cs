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
    public int damage = 25;
    public bool hasOwner = false;
    public bool isThrown = false;
    public GameObject thrownBy;
    
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
    }

    public void PickupByPlayer(UnitController unitController)
    {

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
        // upon hitting a AI/player, call the Player's UnitController TakeDamage() function. Make sure the "colliding" ball wasn't thrown by the same person its colliding with
        else if (c.gameObject.layer == LayerMask.NameToLayer("Player") && isThrown == true && c.gameObject != thrownBy) 
        {
            UnitController uc = c.gameObject.GetComponent<UnitController>();
            if (uc != null)
            {
                uc.TakeDamage(damage); // fixed damage for now
                isThrown = false; // eliminate taking damage twice before the ball hits the ground
            }

            UnitController unit = c.gameObject.GetComponent<UnitController>();
            if (unit != null)
            {
                unit.TakeDamage(damage); // fixed damage for now
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
}
