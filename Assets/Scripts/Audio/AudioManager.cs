using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // public List<
    [SerializeField] public AudioTrack[] backgroundTracks;
    private int currentTrackIndex = 0;
    [SerializeField] string currentTrack;
    [SerializeField] public AudioSource musicAudioSource;
    public AudioMixer mixer;
    public static AudioManager _instance;

    void Awake()
    {
        
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
        if(!musicAudioSource)
        {
            musicAudioSource = GetComponent<AudioSource>();
        } 
    }
    void Start()
    {
        Shuffle();
        
        // backgroundTracks.
        PlayNextTrack();
    }
    public void Shuffle() {
        for (int i = 0; i < backgroundTracks.Length; i++) {
            int rnd = Random.Range(0, backgroundTracks.Length);
            AudioTrack temp = backgroundTracks[rnd];
            backgroundTracks[rnd] = backgroundTracks[i];
            backgroundTracks[i] = temp;
        }
    }
    public void SetVolMaster(float sliderValue)
    {
        mixer.SetFloat("VolMusic",Mathf.Log10(sliderValue)*20);
    }
    public void SetVolMusic(float sliderValue)
    {
        mixer.SetFloat("VolMaster",Mathf.Log10(sliderValue)*20);
    }
    void Update()
    {
        if(musicAudioSource.isPlaying == false)
        {
            PlayNextTrack();
        }
    }
    public void PlayNextTrack()
    {
        musicAudioSource.clip = backgroundTracks[currentTrackIndex].audioClip;
        musicAudioSource.volume = backgroundTracks[currentTrackIndex].volume;
        musicAudioSource.pitch = backgroundTracks[currentTrackIndex].pitch;
        currentTrack = backgroundTracks[currentTrackIndex].trackName;
        musicAudioSource.Play();
        currentTrackIndex++;
        if(currentTrackIndex >= backgroundTracks.Length) { currentTrackIndex=0;}
    }
}
