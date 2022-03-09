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
